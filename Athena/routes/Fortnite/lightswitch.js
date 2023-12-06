const express = require('express');
const app = express();
const axios = require('axios')

app.get('/lightswitch/api/service/bulk/status', async (req, res) => {
    const serviceId = req.query.serviceId ? req.query.serviceId.toLowerCase() : "fortnite";
    // res.json([{
    //     'serviceInstanceId': serviceId,
    //     'status': 'UP',
    //     'message': 'Hi',
    //     'maintenanceUri': "https://dsc.gg/Atomic",
    //     'allowedActions': [],
    //     'banned': false,
    //     'launcherInfoDTO': {
    //       'appName': "Fortnite",
    //       'catalogItemId': "4fe75bbc5a674f4f9b356b5c90567da5",
    //       'namespace': 'fn'
    //     }
    // }]);
    res.json(
      [
        {
          "serviceInstanceId": "fortnite",
          "status": "UP",
          "message": "Fortnite is online",
          "maintenanceUri": null,
          "overrideCatalogIds": [
            "a7f138b2e51945ffbfdacc1af0541053"
          ],
          "allowedActions": [],
          "banned": false,
          "launcherInfoDTO": {
            "appName": "Fortnite",
            "catalogItemId": "4fe75bbc5a674f4f9b356b5c90567da5",
            "namespace": "fn"
          }
        }
      ]
    )
})

app.get('/lightswitch/api/service/:serviceId/status', async (req, res) => {
    const serviceId = req.params.serviceId ? req.params.serviceId.toLowerCase() : "fortnite";
    res.json({
      'serviceInstanceId': serviceId,
      'status': 'UP',
      'message': "Hello",
      'maintenanceUri': "https://dsc.gg/Atomic",
      'allowedActions': [],
      'banned': false,
      'launcherInfoDTO': {
        'appName': "Fortnite",
        'catalogItemId': '4fe75bbc5a674f4f9b356b5c90567da5',
        'namespace': 'fn'
      }
    });
})

app.all('/api/json', (req, res) => res.json({}))
app.get('/account/api/public/account/:accountId/externalAuths', (req, res) => res.json([]))

app.get("/launcher/api/public/assets/:platform/:catalogItemId/:appName", async (req, res) => {
    const _0x2e8fd2 = (await axios.post("https://account-public-service-prod.ol.epicgames.com/account/api/oauth/token", "grant_type=client_credentials", {
      'headers': {
        'Content-Type': 'application/x-www-form-urlencoded',
        'Authorization': "Basic M2Y2OWU1NmM3NjQ5NDkyYzhjYzI5ZjFhZjA4YThhMTI6YjUxZWU5Y2IxMjIzNGY1MGE2OWVmYTY3ZWY1MzgxMmU="
      }
    })).data.access_token;
    axios.get("https://launcher-public-service-prod06.ol.epicgames.com" + req.url, {
      'headers': {
        'authorization': "bearer " + _0x2e8fd2
      }
    }).then(_0xf44063 => {
      res.json(_0xf44063.data);
    })["catch"](_0x1a060c => {
      res.json({
        'appName': req.query.appName,
        'labelName': req.headers["user-agent"].split(" ")[0x0] || req.headers["user-agent"],
        'buildVersion': req.headers["user-agent"].split(" ")[0x0] || req.headers["user-agent"],
        'catalogItemId': req.params.catalogItemId,
        'expires': new Date().addHours(0x2),
        'items': {
          'MANIFEST': {
            'signature': 'ak_token=exp=1619828899~hmac=1968bf14793626dc350d50e03ae92004cff698dcb8276688e175f394b8b8f268',
            'distribution': "https://epicgames-download1.akamaized.net/",
            'path': "Builds/Fortnite/Content/CloudDir/9rt_NKT5rwdY4PthEU24o6SUQYYdfA.manifest",
            'hash': "2817e928c4e0cdce735e8328e37d6fd5338134df",
            'additionalDistributions': []
          },
          'CHUNKS': {
            'signature': "ak_token=exp=1619828899~hmac=1968bf14793626dc350d50e03ae92004cff698dcb8276688e175f394b8b8f268",
            'distribution': "https://epicgames-download1.akamaized.net/",
            'path': "Builds/Fortnite/Content/CloudDir/9rt_NKT5rwdY4PthEU24o6SUQYYdfA.manifest",
            'additionalDistributions': []
          }
        },
        'assetId': "FortniteContentBuilds"
      });
    });
});

app.get("/launcher/api/public/distributionpoints/", (req, res) => {
    res.json({
      'distributions': ['https://download.epicgames.com/', "https://download2.epicgames.com/", "https://download3.epicgames.com/", "https://download4.epicgames.com/", 'https://epicgames-download1.akamaized.net/', "https://fastly-download.epicgames.com/"]
    });
  });
app.post("/api/v1/user/setting", (req, res) => {
    res.json([{
      'accountId': req.body.accountId,
      'key': "avatar",
      'value': "cid_003_athena_commando_f_default"
    }, {
      'accountId': req.body.accountId,
      'key': "avatarBackground",
      'value': "[\"#B4F2FE\",\"#00ACF2\",\"#005679\"]"
    }, {
      'accountId': req.body.accountId,
      'key': "appInstalled",
      'value': "init"
    }]);
  });
  app.post('/api/v1/fortnite-br/surfaces/motd/target', async (req, res) => {
    res.json({
      'contentId': "motd-default-collection",
      'contentType': "collection",
      'tcId': util.randomString(0x24),
      'contentItems': [{
        'contentFields': {
          'title': "Hybrid Server",
          'body': "Hybrid Server by Pankiefield",
          'buttonTextOverride': "Join the discord!",
          'entryType': "Button",
          'tabTitleOverride': "Hybrid Server",
          'image': [{
            'height': 0x3fe,
            'width': 0x726,
            'url': "https://files.prankielief.repl.co/public/news_big.jpg"
          }],
          'tileImage': [{
            'height': 0x393,
            'width': 0x724,
            'url': "https://files.prankielief.repl.co/public/news_small.png"
          }],
          'videoStreamingEnabled': true,
          'videoMute': false,
          'videoLoop': true,
          'videoAutoplay': true
        },
        'contentSchemaName': 'Motd',
        'contentType': "content-item",
        'contentId': util.randomString(0x24),
        'tcId': util.randomString(0x24)
      }]
    });
  });
  app.get("/api/v1/assets/Fortnite/:version/", (req, res) => {
    res.json([]);
  });
  app.get("/fortnite/api/game/v2/world/info", (req, _0xb0a549) => _0xb0a549.json({}));
  app.get('/friends/api/v1/*/blocklist', (req, _0x5cbef0) => {
    _0x5cbef0.json([]);
  });
  app.get("/eulatracking/api/public/agreements/*/account/:accountId", (req, _0x25935a) => {
    _0x25935a.status(0xcc).end();
  });
  app.get("/friends/api/v1/*/recent/fortnite", (req, _0x575496) => {
    _0x575496.json([]);
  });
  app.get('/api/v1/events/:game/download/:accountId', (req, _0x195580) => {
    _0x195580.json({
      'player': {
        'gameId': req.params.game,
        'accountId': req.params.accountId,
        'tokens': [],
        'teams': {},
        'pendingPayouts': [],
        'pendingPenalties': {},
        'persistentScores': {},
        'groupIdentity': {}
      },
      'events': [],
      'templates': [],
      'scores': []
    });
  });
  app.get('/fortnite/api/game/v2/br-inventory/account/:accountId', (req, _0x5618a5) => {
    _0x5618a5.json({
      'stash': {
        'globalcash': 0x0
      }
    });
  });
  app.get("/catalog/api/shared/bulk/offers", (req, _0xd586de) => {
    _0xd586de.json({});
  });
  app.get("/fortnite/api/v2/versioncheck/:version", (req, _0x517175) => {
    _0x517175.json({
      'type': 'NO_UPDATE'
    });
  });
  app.get("/fortnite/api/game/v2/privacy/account/:accountId", (req, _0x544458) => {
    _0x544458.json({
      'accountId': req.params.accountId,
      'optOutOfPublicLeaderboards': false
    });
  });
  app.post("/api/v1/assets/Fortnite/:version/:netcl", (req, _0x585510) => {
    _0x585510.json({
      'FortPlaylistAthena': {
        'meta': {
          'promotion': 0x0
        },
        'assets': {}
      }
    });
  });
  app.all("/fortnite/api/game/v2/matchmakingservice/ticket/player/:accountId", (req, _0x435e87) => {
    var _0x2ed8f1 = {
      'NetCL': '',
      'Region': '',
      'Playlist': '',
      'HotfixVerion': -0x1
    };
    try {
      var _0x522807 = req.query.bucketId.split(':');
      _0x2ed8f1.NetCL = _0x522807[0x0];
      _0x2ed8f1.HotfixVerion = _0x522807[0x1];
      _0x2ed8f1.Region = _0x522807[0x2];
      _0x2ed8f1.Playlist = _0x522807[0x3];
    } catch {
      throw new ApiException(errors.com.epicgames.fortnite.invalid_bucket_id);
    } finally {
      if (true || true || true || false) {
        throw new ApiException(errors.com.epicgames.fortnite.invalid_bucket_id).withMessage("Failed to parse bucketId: '" + req.query.bucketId + "'")["with"](req.query.bucketId);
      }
    }
    _0x435e87.cookie('NetCL', '');
    var _0x363d03 = {
      'playerId': req.params.accountId,
      'partyPlayerIds': [req.params.accountId],
      'bucketId': "FN:Live::" + _0x2ed8f1.HotfixVerion + ':' + '' + ':' + '' + ':PC:public:1',
      'attributes': {
        'player.userAgent': req.headers["user-agent"],
        'player.preferredSubregion': "None",
        'player.option.spectator': "false",
        'player.inputTypes': '',
        'playlist.revision': '1',
        'player.teamFormat': "fun"
      },
      'expireAt': new Date().addHours(0x1),
      'nonce': _0x38a029(0x20)
    };
    Object.entries(req.query).forEach(([_0xafad7b, _0x203211]) => {
      if (_0xafad7b == 'player.subregions' && _0x203211.includes(',')) {
        _0x363d03.attributes['player.preferredSubregion'] = _0x203211.split(',')[0x0];
      }
      _0x363d03.attributes[_0xafad7b] = _0x203211;
    });
    var _0x3c107d = Buffer.from(JSON.stringify(_0x363d03, null, 0x0)).toString("base64");
    _0x435e87.json({
      'serviceUrl': 'ws://matchmaking-fn.herokuapp.com/',
      'ticketType': "mms-player",
      'payload': _0x3c107d,
      'signature': "DeezNuts"
    });
  });
  app.get("/fortnite/api/game/v2/matchmaking/account/:accountId/session/:sessionId", (req, _0x4a7c4b) => _0x4a7c4b.json({
    'accountId': req.params.accountId,
    'sessionId': req.params.sessionId,
    'key': "none"
  }));
  app.post("/fortnite/api/matchmaking/session/:SessionId/join", (req, _0x13c1cb) => _0x13c1cb.status(0xcc).end());
  app.get("/fortnite/api/matchmaking/session/:sessionId", (_0x104ea6, _0x9862af) => {
    var _0x12ea7c = _0x104ea6.cookies.NetCL;
    _0x9862af.json({
      'id': _0x104ea6.params.sessionId,
      'ownerId': "Reloaded",
      'ownerName': "Reloaded",
      'serverName': "Reloaded",
      'serverAddress': '127.0.0.1',
      'serverPort': -0x1,
      'totalPlayers': 0x0,
      'maxPublicPlayers': 0x0,
      'openPublicPlayers': 0x0,
      'maxPrivatePlayers': 0x0,
      'openPrivatePlayers': 0x0,
      'attributes': {},
      'publicPlayers': [],
      'privatePlayers': [],
      'allowJoinInProgress': false,
      'shouldAdvertise': false,
      'isDedicated': false,
      'usesStats': false,
      'allowInvites': false,
      'usesPresence': false,
      'allowJoinViaPresence': true,
      'allowJoinViaPresenceFriendsOnly': false,
      'buildUniqueId': _0x12ea7c || '00000000',
      'lastUpdated': "2020-11-09T00:40:28.878Z",
      'started': false
    });
  });
  app.get("/waitingroom/api/waitingroom", (req, _0x2e24b9) => {
    _0x2e24b9.status(0xcc).end();
  });
  app.post("/fortnite/api/game/v2/grant_access/:accountId", (req, _0x44a3f9) => {
    _0x44a3f9.status(0xcc).end();
  });
  app.get("/fortnite/api/game/v2/enabled_features", (req, _0x437736) => {
    _0x437736.json([]);
  });
  app.get("/fortnite/api/receipts/v1/account/:accountId/receipts", (req, _0x4f2f75) => {
    _0x4f2f75.json([]);
  });
  app.get("/friends/api/public/blocklist/:accountId", (req, _0x58524f) => {
    _0x58524f.json({
      'blockedUsers': []
    });
  });
  app.get("/friends/api/v1/:accountId/settings", (req, _0x43e446) => {
    _0x43e446.json({
      'acceptInvites': "public"
    });
  });
  app.get('/friends/api/public/list/fortnite/:accountId/recentPlayers', (req, _0x5a865d) => {
    _0x5a865d.json([]);
  });
  app.get('/friends/api/public/friends/:accountId', (req, _0x1987cb) => {
    _0x1987cb.json([{
      'accountId': req.params.accountId,
      'status': "ACCEPTED",
      'direction': 'INBOUND',
      'created': "2018-12-06T04:46:01.296Z",
      'favorite': false
    }]);
  });
  app.post("/datarouter/api/v1/public/*", (req, _0x4949db) => {
    _0x4949db.status(0xcc).end();
  });
  app.get('/presence/api/v1/_/:accountId/settings/subscriptions', (req, _0x1f38d0) => {
    _0x1f38d0.status(0xcc).end();
  });
  app.get("/party/api/v1/Fortnite/user/:accountId/notifications/undelivered/count", (req, _0xe1322a) => {
    _0xe1322a.status(0xcc).end();
  });
  app.get("/socialban/api/public/v1/:accountId", (req, _0x44b87d) => {
    _0x44b87d.status(0xcc).end();
  });
  app.get("/content-controls/:accountId", function (req, _0x38d618) {
    _0x38d618.status(0xcc).end();
  });
  app.post("/fortnite/api/game/v2/tryPlayOnPlatform/account/:accountId", (req, _0x1cb543) => {
    _0x1cb543.set("Content-Type", "text/plain");
    _0x1cb543.send(true);
  });
  app.get("/affiliate/api/public/affiliates/slug/:affiliateName", (req, _0x1f4958) => {
    if (req.params.affiliateName != 'Atomic') {
      throw new ApiException(errors.com.epicgames.ecommerce.affiliate.not_found)["with"](req.params.affiliateName);
    }
    _0x1f4958.json({
      'id': 'aabbccddeeff11223344556677889900',
      'slug': req.params.affiliateName,
      'displayName': req.params.affiliateName,
      'status': "ACTIVE",
      'verified': true
    });
  });
  app.get("/content-controls/:accountId", (req, _0x3344ed) => {
    _0x3344ed.status(0x194);
    _0x3344ed.json({
      'errorCode': 'errors.com.epicgames.content_controls.errors.com.epicgames.content_controls.no_user_config_found',
      'message': "No user found with provided principal id"
    });
  });
  app.get('/statsproxy/api/statsv2/account/:accountId', (req, _0x6e571) => {
    _0x6e571.json({
      'startTime': 0x0,
      'endTime': 0x8000000000000000,
      'stats': {},
      'accountId': req.params.accountId
    });
  });
  app.get("/fortnite/api/cloudstorage/system/DefaultGame.ini", (req, _0x2e886c) => {
    _0x2e886c.setHeader("content-type", 'application/octet-stream');
    _0x2e886c.sendFile(path.join(__dirname, "../../cloudstorage/DefaultGame.ini"));
  });
  app.get("/fortnite/api/cloudstorage/user/:accountId", (req, _0x30f71f) => {
    _0x30f71f.json([]);
  });
  app.put("/fortnite/api/cloudstorage/user/:accountId/:filename", (req, _0x11a34d) => _0x11a34d.status(0xcc).end());
  app.post("/fortnite/api/game/v2/profileToken/verify/*", (req, _0x438818) => {
    _0x438818.status(0xcc).end();
  });
  app.get("/fortnite/api/storefront/v2/keychain", (req, _0x18664f) => {
    axios.get("https://api.nitestats.com/v1/epic/keychain", {
      'timeout': 0xbb8
    }).then(_0x2a0039 => {
      _0x18664f.json(_0x2a0039.data);
    })["catch"](_0x5a0c49 => {
      _0x18664f.json(['74AF07F9A2908BB2C32C9B07BC998560:V0Oqo/JGdPq3K1fX3JQRzwjCQMK7bV4QoyqQQFsIf0k=:Glider_ID_158_Hairy']);
    });
  });
  app.get("/fortnite/api/matchmaking/session/findPlayer/:id", (req, _0x27e905) => {
    _0x27e905.json([]);
  });
  app.get("/fortnite/api/statsv2/account/:accountId", (req, _0x48e60f) => {
    _0x48e60f.json([]);
  });
  app.get("/lightswitch/api/fn/mnemonic/:playlist", (req, _0x5c12f6) => _0x5c12f6.json({
    'namespace': 'fn',
    'accountId': "epic",
    'creatorName': "Epic",
    'mnemonic': req.params.playlist,
    'linkType': "BR:Playlist",
    'metadata': {
      'matchmaking': {
        'override_playlist': req.params.playlist
      }
    },
    'version': 0x5d,
    'active': true,
    'disabled': false,
    'created': "2021-08-16T16:43:18.268Z",
    'published': "2021-08-03T15:27:17.540Z",
    'descriptionTags': []
  }));
  function _0x38a029(_0xaf7343) {
    var _0x1cce18 = [];
    var _0x338950 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".length;
    for (var _0x109f92 = 0x0; _0x109f92 < _0xaf7343; _0x109f92++) {
      _0x1cce18.push("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".charAt(Math.floor(Math.random() * _0x338950)));
    }
    return _0x1cce18.join('');
  }
  
module.exports = app;