const express = require('express')
const app = express();
const fs = require('fs')
const config = require('../../config')
const IP = require('ip');

app.get('/api/v1/vbucks', async (req, res) => {
    const vbucks = parseInt(req.headers['vbucks'])
    const accountId = req.headers['accountid']
    fs.readFile(`${config.dir}/trash/profiles/${accountId}.json`, 'utf-8', (err, jsonString) => {
      if (err) {
        res.send(err);
      } else {
        const data = JSON.parse(jsonString);
        data.vbucks = vbucks;
        res.send('Changed vbucks for ' + accountId + " to " + vbucks);
        fs.writeFile(`${config.dir}/trash/profiles/${accountId}.json`, JSON.stringify(data, null, 2), function writeJSON(err) {
          if (err) return console.log(err);
        })
      }
    });
})

app.get('/api/v1/level', async (req, res) => {
    const level = parseInt(req.headers['level'])
    const accountId = req.headers['accountid']
    fs.readFile(`${config.dir}/trash/profiles/${accountId}.json`, 'utf-8', (err, jsonString) => {
      if (err) {
        res.send(err);
      } else {
        const data = JSON.parse(jsonString);
        data.level = level;
        res.send('Changed level for ' + accountId + " to " + level);
        fs.writeFile(`${config.dir}/trash/profiles/${accountId}.json`, JSON.stringify(data, null, 2), function writeJSON(err) {
          if (err) return console.log(err);
        })
      }
    });
})

app.get('/api/v1/battlestars', async (req, res) => {
    const battlestars = parseInt(req.headers['battlestars'])
    const accountId = req.headers['accountid']
    fs.readFile(`${config.dir}/trash/profiles/${accountId}.json`, 'utf-8', (err, jsonString) => {
      if (err) {
        res.send(err);
      } else {
        const data = JSON.parse(jsonString);
        data.battlestars = battlestars;
        res.send('Changed battlestars for ' + accountId + " to " + battlestars);
        fs.writeFile(`${config.dir}/trash/profiles/${accountId}.json`, JSON.stringify(data, null, 2), function writeJSON(err) {
          if (err) return console.log(err);
        })
      }
    });
}) 

app.get('/api/v1/crownwins', async (req, res) => {
  const crownwins = parseInt(req.headers['crownwins'])
  const accountId = req.headers['accountid']
  fs.readFile(`${config.dir}/trash/profiles/${accountId}.json`, 'utf-8', (err, jsonString) => {
    if (err) {
      res.send(err);
    } else {
      const data = JSON.parse(jsonString);
      data.crownwins = crownwins;
      res.send('Changed crownwins for ' + accountId + " to " + crownwins);
      fs.writeFile(`${config.dir}/trash/profiles/${accountId}.json`, JSON.stringify(data, null, 2), function writeJSON(err) {
        if (err) return console.log(err);
      })
    }
  });
})

app.get('/api/v1/rank', async (req, res) => {
  const rank = parseInt(req.headers['rank'])
  const accountId = req.headers['accountid']
  const type = req.headers['type']
  fs.readFile(`${config.dir}/trash/profiles/${accountId}.json`, 'utf-8', (err, jsonString) => {
    if (err) {
      res.send(err);
    } else {
      const data = JSON.parse(jsonString);
      data[type] = rank;
      res.send(`Changed ${type} for ` + accountId + " to " + rank);
      fs.writeFile(`${config.dir}/trash/profiles/${accountId}.json`, JSON.stringify(data, null, 2), function writeJSON(err) {
        if (err) return console.log(err);
      })
    }
  });
})

app.get('/api/v1/lobby', async (req, res) => {
  const lobby = req.headers['lobby']
  fs.readFile(`${config.dir}/trash/customBackgrounds.json`, 'utf-8', (err, jsonString) => {
    if (err) {
      res.send(err);
    } else {
      const data = JSON.parse(jsonString);
      console.log(IP.address())
      data[IP.address()] = lobby;
      res.send(`Changed lobby for ` + IP.address + " to " + lobby);
      fs.writeFile(`${config.dir}/trash/customBackgrounds.json`, JSON.stringify(data, null, 2), function writeJSON(err) {
        if (err) return console.log(err);
      })
    }
  });
})

app.get('/api/v1/hasProfile/:accountId', async (req, res) => {
  const accountId = req.params.accountId
  if (fs.existsSync(`${config.dir}/trash/profiles/${accountId}.json`)) {
    res.send(true)
  } else {
    res.send(false)
  }
})

app.get('/api/v1/createProfile/:accountId', async (req, res) => {
  fs.copyFileSync(`${config.dir}/trash/templates/template.json`, `${config.dir}/trash/profiles/${req.params.accountId}.json`)
})

app.get('/api/v1/getProfile/:accountId', async (req, res) => {
  const accountId = req.params.accountId
  if (!fs.existsSync(`${config.dir}/trash/profiles/${accountId}.json`))
    fs.copyFileSync(`${config.dir}/trash/templates/template.json`, `${config.dir}/trash/profiles/${req.params.accountId}.json`)
  fs.readFile(`${config.dir}/trash/profiles/${accountId}.json`, 'utf-8', (err, jsonString) => {
    if (err) {
      res.send(err);
    } else {
      const data = JSON.parse(jsonString)
      res.json(data)
    }
  });
})

module.exports = app;