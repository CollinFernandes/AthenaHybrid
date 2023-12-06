const express = require("express");
const app = express();

app.post([ "/api/v1/fortnite-br/surfaces/eco-motd/target", "/api/v1/fortnite-br/surfaces/br-motd/target" ], (req, res) => {
  var contentId = "fortnite-br-eco-motd-collection";
  if (req.url == "/api/v1/fortnite-br/surfaces/eco-motd/target") {
    contentId = "fortnite-br-eco-motd-collection";
  } else if (req.url == "/api/v1/fortnite-br/surfaces/br-motd/target") {
    contentId = "fortnite-br-br-motd-collection";
  }
  res.json({
    "contentId": contentId,
    "contentItems": [
      {
        "contentType": "content-item",
        "contentId": "fb800f0f-4254-4b03-a692-699e517994c6",
        "tcId": "80b189af-0b66-498f-b7ef-700e882597dd",
        "contentFields": {
          "FullScreenBackground": {
            "Image": [
              {
                "width": 1920,
                "height": 1080,
                "url": "https://media.discordapp.net/attachments/1051538904840413315/1174040918475669614/1920x1080.png?ex=656625cf&is=6553b0cf&hm=bf29d7934df029a5417166ca8b8fda23358edcec49ea75ce8bb3a2c64d6d6205&"
              },
              {
                "width": 960,
                "height": 540,
                "url": "https://media.discordapp.net/attachments/1051538904840413315/1174040924133789716/960x540.png?ex=656625d0&is=6553b0d0&hm=09fafbc0bb88c8dd9cfa10f419253a2710b4309a6fb65a79398f27a9c6962b42&"
              }
            ],
            "_type": "FullScreenBackground"
          },
          "FullScreenBody": "test MOTD for Athena Hybrid. Made by basicfx",
          "FullScreenTabTitle": "Athena Hybrid",
          "FullScreenTitle": "Athena Hybrid",
          "TeaserBackground": {
            "Image": [
              {
                "width": 1024,
                "height": 512,
                "url": "https://media.discordapp.net/attachments/1051538904840413315/1174040944526491668/1024x512.png?ex=656625d5&is=6553b0d5&hm=2e6a551259f9ac0549fed7c82fd471157602c825adb3e09b7381500a40411f2e&"
              }
            ],
            "_type": "TeaserBackground"
          },
          "TeaserTitle": "Athena Hybrid"
        },
        "contentSchemaName": "DynamicMotd",
        "contentHash": "03d5ea4cdbe83ece0fb9255a545fc00f"
      },
      // {
      //   "contentType": "content-item",
      //   "contentId": "1c077f3e-f194-4452-afa6-147d831370c6",
      //   "tcId": "6ca35c53-0b31-45fb-b1f9-48cd90925510",
      //   "contentFields": {
      //     "Buttons": [
      //       {
      //         "Action": {
      //           "_type": "MotdNavigateToShopAction",
      //           "navAction": "1",
      //           "offerTrackingId": "/Game/Catalog/NewDisplayAssets/DAv2_CID_493_F_JurassicArchaeology.DAv2_CID_493_F_JurassicArchaeology"
      //         },
      //         "Style": "0",
      //         "Text": "Ansehen",
      //         "_type": "Button"
      //       }
      //     ],
      //     "FullScreenBackground": {
      //       "Image": [
      //         {
      //           "width": 1920,
      //           "height": 1080,
      //           "url": "https://cdn-live.prm.ol.epicgames.com/prod/82176fffc21216459f4528756fa1e51fdcb00137742bab61dfe404454111d93fb88b3ad1d790bc1f257c696f26082770-41cb8f67-5aff-463f-91b8-c03ca71ed4a8.jpeg?width=1920"
      //         },
      //         {
      //           "width": 960,
      //           "height": 540,
      //           "url": "https://cdn-live.prm.ol.epicgames.com/prod/82176fffc21216459f4528756fa1e51fdcb00137742bab61dfe404454111d93fb88b3ad1d790bc1f257c696f26082770-41cb8f67-5aff-463f-91b8-c03ca71ed4a8.jpeg?width=960"
      //         }
      //       ],
      //       "_type": "FullScreenBackground"
      //     },
      //     "FullScreenBody": "Schützt die Vergangenheit auf stilvolle Weise.",
      //     "FullScreenTabTitle": "N/A",
      //     "FullScreenTitle": "Saura",
      //     "TeaserBackground": {
      //       "Image": [
      //         {
      //           "width": 1024,
      //           "height": 512,
      //           "url": "https://cdn-live.prm.ol.epicgames.com/prod/82176fffc21216459f4528756fa1e51fe34408f23e3bd749a5867bc521d7dafa5e17d255f44797e1ac7188129171ec26-3bbb8dc3-0ca2-4759-b1fd-e7237f35b367.jpeg?width=1024"
      //         }
      //       ],
      //       "_type": "TeaserBackground"
      //     },
      //     "TeaserTitle": "Neues Outfit"
      //   },
      //   "contentSchemaName": "DynamicMotd",
      //   "contentHash": "829b623a4829dbba2474031cbe0cfb2d"
      // },
      // {
      //   "contentType": "content-item",
      //   "contentId": "910dc0af-4c7a-4025-bbfd-043d4feeb5f3",
      //   "tcId": "6a7d2046-1cd7-4539-9a6d-71b2139d06b3",
      //   "contentFields": {
      //     "FullScreenBackground": {
      //       "Image": [
      //         {
      //           "width": 1920,
      //           "height": 1080,
      //           "url": "https://cdn-live.prm.ol.epicgames.com/prod/edb4e1aed615f6be7e1b0b2551a1786f2ed8d203e70d5854aa91134b041948bd50e6d38c741fbf3ab973ea42fb0afcbd-7b8efa64-ce4a-4008-a004-5de81141e2d9.jpeg?width=1920"
      //         },
      //         {
      //           "width": 960,
      //           "height": 540,
      //           "url": "https://cdn-live.prm.ol.epicgames.com/prod/edb4e1aed615f6be7e1b0b2551a1786f2ed8d203e70d5854aa91134b041948bd50e6d38c741fbf3ab973ea42fb0afcbd-7b8efa64-ce4a-4008-a004-5de81141e2d9.jpeg?width=960"
      //         }
      //       ],
      //       "_type": "FullScreenBackground"
      //     },
      //     "FullScreenBody": "Greift eure Gegner mit den Klassikern an. Das Sturmgewehr, die Pumpgun und der Greifer kehren für Fortnite: OG allesamt zurück!",
      //     "FullScreenTabTitle": "N/A",
      //     "FullScreenTitle": "Fortnite: OG – Waffen und Gegenstände in Woche 1",
      //     "TeaserBackground": {
      //       "Image": [
      //         {
      //           "width": 1024,
      //           "height": 512,
      //           "url": "https://cdn-live.prm.ol.epicgames.com/prod/edb4e1aed615f6be7e1b0b2551a1786fd75855c326aa9eeee26d044bcc0b69a3c261fe3e5b16d528853a1eb71f8660e5-73a373a9-33f8-4256-8466-0bc9059b8a32.jpeg?width=1024"
      //         }
      //       ],
      //       "_type": "TeaserBackground"
      //     },
      //     "TeaserTitle": "Waffen und Gegenstände in Woche 1"
      //   },
      //   "contentSchemaName": "DynamicMotd",
      //   "contentHash": "da22d250e54c38f98b58e9fba5d0c086"
      // },
      // {
      //   "contentType": "content-item",
      //   "contentId": "09506aae-130e-4020-9797-88c46227c99a",
      //   "tcId": "dd6931e8-e498-4b68-92b7-870b3187c2be",
      //   "contentFields": {
      //     "Buttons": [
      //       {
      //         "Action": {
      //           "_type": "MotdChallengeAction",
      //           "challengeCategory": "ChallengeCategory.Weekly.01.Quest"
      //         },
      //         "Style": "0",
      //         "Text": "Aufträge anzeigen",
      //         "_type": "Button"
      //       }
      //     ],
      //     "FullScreenBackground": {
      //       "Image": [
      //         {
      //           "width": 1920,
      //           "height": 1080,
      //           "url": "https://cdn-live.prm.ol.epicgames.com/prod/ca588385243d78e1c25f7db8d219565aa3d02dc81185bcdc6a845640186debf37a54c8a7143168a8242eff88ea88cf7c-b74e241a-a73e-4dac-ae86-18b2cec1e440.jpeg?width=1920"
      //         },
      //         {
      //           "width": 960,
      //           "height": 540,
      //           "url": "https://cdn-live.prm.ol.epicgames.com/prod/ca588385243d78e1c25f7db8d219565aa3d02dc81185bcdc6a845640186debf37a54c8a7143168a8242eff88ea88cf7c-b74e241a-a73e-4dac-ae86-18b2cec1e440.jpeg?width=960"
      //         }
      //       ],
      //       "_type": "FullScreenBackground"
      //     },
      //     "FullScreenBody": "Schließt Aufträge aus Woche 1 ab, um EP zu erhalten und im OG Pass voranzukommen!",
      //     "FullScreenTabTitle": "N/A",
      //     "FullScreenTitle": "„Woche 1“-Aufträge",
      //     "TeaserBackground": {
      //       "Image": [
      //         {
      //           "width": 1024,
      //           "height": 512,
      //           "url": "https://cdn-live.prm.ol.epicgames.com/prod/ca588385243d78e1c25f7db8d219565afb12028aa4e83280f7090dc557595254-f31daac1-6ca0-42d9-99c5-9bcd83b83b94.jpeg?width=1024"
      //         }
      //       ],
      //       "_type": "TeaserBackground"
      //     },
      //     "TeaserTitle": "„Woche 1“-Aufträge"
      //   },
      //   "contentSchemaName": "DynamicMotd",
      //   "contentHash": "cdee8524138f0c3dcc03558ca2447cbd"
      // },
      {
        "contentType": "content-item",
        "contentId": "e1bffce5-f436-407b-beb3-e1dba8661463",
        "tcId": "25e991f0-ba10-4265-98ec-d9219e9eeb13",
        "contentFields": {
          "Buttons": [
            {
              "Action": {
                "_type": "MotdWebsiteAction",
                "websiteUrl": "https://discord.gg/athenadev"
              },
              "Style": "1",
              "Text": "Affen",
              "_type": "Button"
            }
          ],
          "FullScreenBackground": {
            "Image": [
              {
                "width": 1920,
                "height": 1080,
                "url": "https://cdn-live.prm.ol.epicgames.com/prod/a0caa263e917de764b3d17c8a5998e7def5492bd3f4f485606e787eef22d0a9b6e97503a1e261252b39917db847879dc-27b8104a-b529-4141-aeef-27406ee8851b.jpeg?width=1920"
              },
              {
                "width": 960,
                "height": 540,
                "url": "https://cdn-live.prm.ol.epicgames.com/prod/a0caa263e917de764b3d17c8a5998e7def5492bd3f4f485606e787eef22d0a9b6e97503a1e261252b39917db847879dc-27b8104a-b529-4141-aeef-27406ee8851b.jpeg?width=960"
              }
            ],
            "_type": "FullScreenBackground"
          },
          "FullScreenBody": "Meldet euch auf der „Hol einen Freund ins Spiel“-Webseite an, ladet bis zu fünf berechtigte Freunde ein und schließt gemeinsam Aufgaben ab, um bis zum 9. Januar kosmetische Belohnungen, darunter das Outfit „Rotschirm“, zu erhalten.",
          "FullScreenTabTitle": "Hol einen Freund ins Spiel",
          "FullScreenTitle": "Hol einen Freund ins Spiel",
          "TeaserBackground": {
            "Image": [
              {
                "width": 1024,
                "height": 512,
                "url": "https://cdn-live.prm.ol.epicgames.com/prod/cbe627d9409c2a74c91caa3da735da0da61fcb16ef136d565d529bc365754b3d843fd09e589d18b910b25836d54d6ca6-219b3099-e60d-40f3-b659-7a0912dc1e37.jpeg?width=1024"
              }
            ],
            "_type": "TeaserBackground"
          },
          "TeaserTitle": "Hol einen Freund ins Spiel"
        },
        "contentSchemaName": "DynamicMotd",
        "contentHash": "bde5c8ae0bcd49631ab29ff7a06f0e36"
      }
    ],
    "contentMeta": [["f8b2d9a0-0abd-4486-9c9a-902cbd7606fa","6517f0b4eaa16d2e14f341d2ff0e2d53"],["9daf090d-efb1-4fde-8667-40510f826c49","8c06b1a5fc9eb149b0f3e081dd4a091d"],["8a03f32c-50ca-442e-808b-81e6ae1dc5b0","f61b320506e807bf43f300d901a9824c"]],
    "contentType": "collection",
    "tcId=828fd060": "6bcd-4cdf-9c09-3938a5882565"
  });
});

module.exports = app;