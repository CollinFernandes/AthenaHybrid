const axios = require('axios')
const fs = require('fs')
config = require(`../config`);
logs = require(`${config.dir}/utils/logs`)

function readTemplate(profileId) {
    return JSON.parse(fs.readFileSync(`${config.dir}/trash/templates/profile_${profileId}.json`))
}

async function updateAthena() {
    const request = await axios.get(config.cosmeticsAPI)
    var profileAthena = readTemplate('athena')
    var items = request.data.data;
    var varItemName = "";
    var varItemValue = "";
    var varItemId = "";
    try {
        items.forEach(item => {
            varItemName = item.name;
            varItemValue = item.type.backendValue;
            varItemId = item.id;
            var cosmeticVariants = [];

            //#region Variants
            if (item.variants) {
                item.variants.forEach(variant => {
                    var Tags = [];
                    variant.options.forEach(option => {
                        Tags.push(option.tag)
                    })
                    cosmeticVariants.push({
                        'channel': variant.channel,
                        'active': Tags[0],
                        'owned': Tags
                    })
                })
            }
            //#endregion
            if (profileAthena.items[`${item.type.backendValue}:${item.id}`]) {
                var itemVariants = profileAthena.items[`${item.type.backendValue}:${item.id}`].attributes.variants
                if (JSON.stringify(itemVariants) === JSON.stringify(cosmeticVariants)) {
                    logs.sendWarningLog(`Skipping! the Item: ${item.name} (${item.id}) [${item.type.backendValue}] does already exist!`)
                    return;
                } else {
                    //#region new Cosmetic
                    profileAthena.items[`${item.type.backendValue}:${item.id}`] = {
                        'templateId': `${item.type.backendValue}:${item.id}`,
                        'attributes': {
                            'max_level_bonus': 0,
                            'level': 1,
                            'item_seen': true,
                            'rnd_sel_cnt': 0,
                            'xp': 0,
                            'variants': cosmeticVariants,
                            'favorite': false
                        },
                        'quantity': 1
                    }
                    //#endregion
                    //#region sendLog
                    logs.sendSuccessLog(`Successfully updated the Item: ${item.name} (${item.id}) [${item.type.backendValue}]!`)
                    //#endregion
                }
            } else {
                //#region new Cosmetic
                profileAthena.items[`${item.type.backendValue}:${item.id}`] = {
                    'templateId': `${item.type.backendValue}:${item.id}`,
                    'attributes': {
                        'max_level_bonus': 0,
                        'level': 1,
                        'item_seen': true,
                        'rnd_sel_cnt': 0,
                        'xp': 0,
                        'variants': cosmeticVariants,
                        'favorite': false
                    },
                    'quantity': 1
                }
                //#endregion
                //#region sendLog
                logs.sendSuccessLog(`Successfully added the Item: ${item.name} (${item.id}) [${item.type.backendValue}] to the Athena profile!`)
                //#endregion
            }
        });
    } catch(err) {
        logs.sendErrorLog(`there was an error while adding the Item: ${varItemName} (${varItemId}) [${varItemValue}] to the Athena profile!\n${err}`)
    }
    try {
        logs.sendSuccessLog(`Successfully saved the Athena profile with all new Cosmetics!`)
        fs.writeFileSync(`${config.dir}/trash/templates/profile_athena.json`, JSON.stringify(profileAthena, null, 2));
        logs.sendWarningLog(`Clearing console in 3 Seconds!!`)
    } catch(err) {
        logs.sendErrorLog(`there was an error while saving the Athena profile!\n${err}`)
    }
}

module.exports = {updateAthena}