const express = require('express')
const app = express();
require("dotenv").config();
const axios = require('axios')

const headers = {
    Authorization: `Bot ${process.env.token}`,
};

app.get("/api/v1/discordData/:id", async (req, res) => {
    const id = req.params.id;
    axios
      .get(
        `https://discord.com/api/guilds/1184157561797226618/members/${id}`,
        { headers }
      )
      .then((response) => {
        const userInfo = response.data;
        const hasRole = userInfo.roles.includes('1184169055515578468');
        const hasRole1 = userInfo.roles.includes('1184169055515578468');
        if (hasRole || hasRole1) {
            res.json({
                isJoined: true,
                isPremium: true
              })
        } else {
            res.json({
                isJoined: true,
                isPremium: false
            })
        }
      })
      .catch((error) => {
        res.json({
            isJoined: false,
            isPremium: false
        })
      });
  });

module.exports = app;