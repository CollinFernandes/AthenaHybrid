const express = require('express');
const app = express();

app.get('/fortnite/api/storefront/v2/catalog', (req, res) => {
res.json(require("../../trash/shop.json"))
});

module.exports = app;