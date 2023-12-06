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
        `https://discord.com/api/guilds/1179054142057095249/members/${id}`,
        { headers }
      )
      .then((response) => {
        const userInfo = response.data;
        const hasRole = userInfo.roles.includes('1179154361453137930');
        const hasRole1 = userInfo.roles.includes('1179154361453137930');
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