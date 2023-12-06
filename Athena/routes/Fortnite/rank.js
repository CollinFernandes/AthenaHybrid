const express = require('express')
const app = express();
const fs = require('fs')

app.get('/api/v1/games/fortnite/trackprogress/:accountId', async (req, res) => {
    const rankData = require("../../trash/rank.json")
    fs.readFile(`${config.dir}/trash/profiles/${req.params.accountId}.json`, 'utf-8', (err, jsonString) => {
        if (err) {
          res.send(err);
        } else {
          const data = JSON.parse(jsonString);
          rankData[1].accountId = req.params.accountId
          rankData[1].currentDivision = data.rankzb
          rankData[1].highestDivision = data.highestrankzb
          rankData[1].promotionProgress = parseFloat(`0.${data.percentagezb}`)
          rankData[0].accountId = req.params.accountId
          rankData[0].currentDivision = data.rankbr
          rankData[0].highestDivision = data.highestrankbr
          rankData[0].promotionProgress = parseFloat(`0.${data.percentagebr}`)
          res.json(rankData);
        }
    });
})

module.exports = app;