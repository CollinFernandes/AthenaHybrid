const express = require('express')
const app = express();

app.all('/fortnite/api/matchmaking/session/:Sid/join', async (req, res) => {
    res.json([]);
})

module.exports = app;