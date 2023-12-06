const express = require('express');
const fs = require('fs');
const config = require('../../config');
const { default: axios } = require('axios');
const app = express();

app.use(express.json())
app.use(express.urlencoded({extended: true}))

app.get('/api/v1/customLocker/get/:accountId', async (req, res) => {
    const accountId = req.params.accountId
    if (await checkLocker(accountId)) {
        res.json(JSON.parse(await getLocker(accountId)))
    } else {
        res.json({})
    }
})

app.post('/api/v1/customLocker/update/:accountId', async (req, res) => {
    const accountId = req.params.accountId
    const data = req.body
    console.log(data)
    updateLocker(data, accountId)
    res.status(200).json({'code': 200, 'message': 'successfully updated locker'});
})

app.get('/api/v1/customLocker/toggle/:accountId/:state', async (req, res) => {
    const accountId = req.params.accountId
    const state = req.params.state
    fs.readFile(`${config.dir}/trash/profiles/${accountId}.json`, 'utf-8', (err, jsonString) => {
      if (err) {
        res.send(err);
      } else {
        const data = JSON.parse(jsonString);
        var stateBool = false;
        if (state == 'true') {
            stateBool = true
        } else if (state == 'false') {
            stateBool = false
        }
        data.customLocker = stateBool;
        res.send('Changed state for ' + accountId + " to " + state);
        fs.writeFile(`${config.dir}/trash/profiles/${accountId}.json`, JSON.stringify(data, null, 2), function writeJSON(err) {
          if (err) return console.log(err);
        })
      }
    });
})

app.get('/api/v1/customLocker/getstate/:accountId', async (req, res) => {
    const accountId = req.params.accountId
    if (fs.existsSync(`${config.dir}/trash/profiles/${accountId}.json`)) {
        fs.readFile(`${config.dir}/trash/profiles/${accountId}.json`, 'utf-8', (err, jsonString) => {
            const data = JSON.parse(jsonString);
            res.send(data.customLocker)
        })
    } else {
        res.send(false);
    }
})

async function getLocker(accountId) {
    if (await checkLocker(accountId)) {
        return fs.readFileSync(`${config.dir}/trash/customLockers/${accountId}.json`)
    }
}

async function checkLocker(accountId) {
    if (fs.existsSync(`${config.dir}/trash/customLockers/${accountId}.json`)) {
        return true
    } else {
        return false
    }
}

async function updateLocker(data, accountId) {
    const request = await axios.get(config.cosmeticsAPI);
    var oldData = fs.readFileSync(`${config.dir}/trash/customLockers/${accountId}.json`);
    var newData = { items: [] };

    data.Cosmetics.forEach(item => {
        var APIItem = Array.from(request.data.data).myFind({ id: item });
        APIItem = APIItem[0];
        varItemName = APIItem.name;
        varItemValue = APIItem.type.backendValue;
        varItemId = APIItem.id;
        var cosmeticVariants = [];

        //#region Variants
        if (APIItem.variants) {
            APIItem.variants.forEach(variant => {
                var Tags = [];
                variant.options.forEach(option => {
                    Tags.push(option.tag);
                });
                cosmeticVariants.push({
                    channel: variant.channel,
                    active: Tags[0],
                    owned: Tags,
                });
            });
        }

        var newItem = {
            templateId: `${APIItem.type.backendValue}:${APIItem.id}`,
            attributes: {
                max_level_bonus: 0,
                level: 1,
                item_seen: true,
                rnd_sel_cnt: 0,
                xp: 0,
                variants: cosmeticVariants,
                favorite: false,
            },
            quantity: 1,
        };

        newData.items.push(newItem);
    });

    fs.writeFileSync(
        `${config.dir}/trash/customLockers/${accountId}.json`,
        JSON.stringify(newData, null, 2)
    );
}

Array.prototype.myFind = function(obj) {
    return this.filter(function(item) {
        for (var prop in obj)
            if (!(prop in item) || obj[prop] !== item[prop])
                 return false;
        return true;
    });
};

module.exports = app;