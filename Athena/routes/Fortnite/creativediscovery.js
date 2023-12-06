const express = require('express');
const app = express();

app.get("/fortnite/api/game/v2/creative/discovery/surface/:userid", (req, res) => {
    res.json(require("../../trash/discovery.json"))
})

module.exports = app;