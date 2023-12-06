const express = require('express');
const app = express();

app.get('/library/api/public/items', (req, res) => {
res.json(require("../../trash/library.json"))
});

module.exports = app;