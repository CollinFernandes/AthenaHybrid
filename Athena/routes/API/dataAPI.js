const express = require('express')
const app = express();
const fs = require('fs')
const config = require('../../config')
const path = require('path')
const axios = require('axios')
require("dotenv").config();

const headers = {
    Authorization: `Bot ${process.env.token}`
};

app.get('/api/v1/data', async(req, res) => {
    var data = JSON.parse(fs.readFileSync(path.join(config.dir, '/trash/data.json')))
    axios.get(`https://discord.com/api/v8/users/749233228996673536`, { headers }).then((response) => {
        var data1 = response.data
        data.DiscordData = [
            {
                "Username": data1.username,
                "Globalname": data1.global_name,
                "ProfilePicture": `https://cdn.discordapp.com/avatars/749233228996673536/${data1.avatar}.png?size=1024`
            }
        ]
        res.json(data)
    })
});

module.exports = app;