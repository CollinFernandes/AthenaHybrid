const express = require('express')
const app = express();
const fs = require('fs')
const axios = require('axios')
const { v4: uuidv4 } = require("uuid");
const {
    checkProfile,
    createProfile,
    loadProfileConfig,
    loadProfile,
    saveProfileConfig,
    createResponse,
    createError,
    createCreative,
    createCommonCore,
    createCommonPublic,
    createCollections,
    createAthena
} = require("../../utils/MCPUtils");
ServiceConfig = require(`../../config`);

function getEquippedItem(slotType, loadoutData) {
    try {
        const loadout = JSON.parse(loadoutData);
        const slots = loadout.slots || [];

        for (const slot of slots) {
            const slotTemplate = slot.slot_template || '';
            const equippedItem = slot.equipped_item || null;

            if (slotTemplate.endsWith(slotType)) {
                return equippedItem;
            }
        }

        return null;  // Slot type not found
    } catch (e) {
        console.error(`Error parsing JSON: ${e}`);
        return null;
    }
}

app.post('/fortnite/api/game/v2/profile/:accountId/client/:command', (req, res) => {
    const command = req.params.command;
    const accountId = req.params.accountId;
    const profileId = req.query.profileId;
    const authorization = req.headers["authorization"];

    var rvn = req.query.rvn;

    checkProfile(accountId)
    let config = loadProfileConfig(accountId)
    let profile = loadProfile(profileId, accountId)

    switch (command) {
        case 'SetCosmeticLockerBanner':
            if (req.body.bannerIconTemplateName != 'None') {
                config.bannerIconTemplate = req.body.bannerIconTemplateName;
            }
            if (req.body.BannerColorTemplate != 'None') {
                config.BannerColorTemplate = req.body.bannerColorTemplate
            }
            saveProfileConfig(ServiceConfig.dir, accountId, config)
            res.json(createResponse(createAthena(config, accountId, profile), profileId,  rvn));
            break;
        case 'ClientQuestLogin':
        case 'QueryProfile':
            switch (profileId) {
                case 'collections':
                    res.json(createResponse(createCollections(config, accountId, profile), profileId)).end()
                    break;
                case 'athena':
                case 'profile0':
                    res.json(createResponse(createAthena(config, accountId, profile), profileId)).end();
                    break;
                case 'creative':
                    res.json(createResponse(createCreative(accountId, profile), profileId)).end();
                    break;
                case 'common_core':
                    res.json(createResponse(createCommonCore(config, accountId, profile), profileId)).end();
                    break;
                case 'common_public':
                    res.json(createResponse(createCommonPublic(accountId, profile), profileId)).end();
                    break;
                case 'collection_book_schematics0':
                case 'collection_book_people0':
                case 'metadata':
                case 'theater0':
                case 'outpost0':
                case 'campaign':
                case 'metadata': 
                    res.json(createResponse([], profileId));
                    break;
                default:
                    res.json(
                    createError('errors.com.epicgames.modules.profiles.operation_forbidden', `Unable to find template configuration for profile ${req.query.profileId}`, 12813, 'fortnite', 'prod-live', [req.query.profileId]));
                    break;
                }
                break;
        case 'SetMtxPlatform':
            res.json(createResponse([{
                changeType: 'statModified',
                name: 'current_mtx_platform',
                value: req.body.platform
            }], profileId, rvn))
            break;
        case 'VerifyRealMoneyPurchase':
            res.json(createResponse(createCommonCore(config, accountId, profile), profileId, rvn))
            break;
        case 'SetRandomCosmeticLoadoutFlag':
            res.json(createResponse(createAthena(config, accountId, profile), profileId, rvn))
            break;
        case 'RedeemRealMoneyPurchases':
            res.json(createResponse(createCommonCore(config, accountId, profile), profileId, rvn))
            break;
        case 'PutModularCosmeticLoadout': 
        const loadoutData = req.body.loadoutData;
        const loadout = JSON.parse(loadoutData);
    
        const profileChanges = [
            {
                attributeName: "slots",
                attributeValue: loadout.slots,
                changeType: "itemAttrChanged",
                itemId: String(uuidv4()),
            },
            {
                attributeName: "user_tags",
                attributeValue: [],
                changeType: "itemAttrChanged",
                itemId: String(uuidv4()),
            },
        ];
    
        const jsonResponse = {
            "profileChanges": profileChanges,
            "profileChangesBaseRevision": Math.floor(Math.random() * 99999) + 1,
            "profileCommandRevision": Math.floor(Math.random() * 99999) + 1,
            "profileId": "athena",
            "profileRevision": Math.floor(Math.random() * 99999) + 1,
            "responseVersion": Math.floor(Math.random() * 99999) + 1,
            "serverTime": new Date().toISOString().slice(0, -1) + "Z",
        };
        res.json(jsonResponse);
            break;
        case 'ClaimMfaEnabled':
            rvn += 1;
            res.json(createResponse(createCommonCore(config, accountId, profile), profileId, rvn))
            break;
        case 'SetItemFavoriteStatusBatch':
            let index = 0;
            for (item of req.body.itemIds) {
                if (req.body.itemFavStatus[index] === true) {
                    var isAlreadyFavorized = false;
                    for (item of config.favorites) {
                        if (item.id === req.body.itemIds[index]) {
                            isAlreadyFavorized = true;
                            break;
                        }
                    }
                    if (!isAlreadyFavorized) {
                        config.favorites.push({id: req.body.itemIds[index]});
                    }
                } else {
                    var Index1 = 0;
                    for (item of config.favorites) {
                        if (item.id === req.body.itemIds[index]) {
                            config.favorites.splice(Index1, 1);
                            break;
                        }
                        Index1 += 1;
                    }
                }
                index += 1;
            }
            saveProfileConfig(ServiceConfig.dir, accountId, config)
            res.json(createResponse(createAthena(config, accountId, profile), profileId, rvn))
            break;
        case 'SetCosmeticLockerSlot':
        case 'SetCosmeticLockerSlots':
                const itemToSlot = req.body.itemToSlot;
                const indexSlot = req.body.slotIndex;
                const slotName = req.body.category;
                const variantUpdates = req.body.variantUpdates;
        
                switch (slotName) {
                  case 'Character':
                  case 'Backpack':
                  case 'Pickaxe':
                  case 'Glider':
                  case 'SkyDiveContrail':
                  case 'MusicPack':
                  case 'LoadingScreen':
                    config[slotName].ID = itemToSlot;
                    config[slotName].Variants = [{ variants: variantUpdates }];
        
                  case 'Dance':
                    config[slotName].ID[indexSlot] = itemToSlot;
                    config[slotName].Variants[indexSlot] = [
                      { variants: variantUpdates }
                    ];
        
                  case 'ItemWrap':
                    if (indexSlot != -1) {
                      config[slotName].ID[indexSlot] = itemToSlot;
                      config[slotName].Variants[indexSlot] = [
                        { variants: variantUpdates }
                      ];
                    }
                    else {
                      config[slotName].ID[0] = itemToSlot;
                      config[slotName].Variants[0] = [{ variants: variantUpdates }];
                      config[slotName].ID[1] = itemToSlot;
                      config[slotName].Variants[1] = [{ variants: variantUpdates }];
                      config[slotName].ID[2] = itemToSlot;
                      config[slotName].Variants[2] = [{ variants: variantUpdates }];
                      config[slotName].ID[3] = itemToSlot;
                      config[slotName].Variants[3] = [{ variants: variantUpdates }];
                      config[slotName].ID[4] = itemToSlot;
                      config[slotName].Variants[4] = [{ variants: variantUpdates }];
                      config[slotName].ID[5] = itemToSlot;
                      config[slotName].Variants[5] = [{ variants: variantUpdates }];
                      config[slotName].ID[6] = itemToSlot;
                      config[slotName].Variants[6] = [{ variants: variantUpdates }];
                    }
        
                    saveProfileConfig(ServiceConfig.dir, accountId, config);
                    break;
                }
                var newAthena = createAthena(config, accountId, profile);
                res.json(createResponse(newAthena, profileId, rvn));
                break;
        default:
            res.json(createError('errors.com.epicgames.modules.profiles.operation_forbidden', `Unable to find template configuration for profile ${ req.query.profileId }`, 12813, 'fortnite', 'prod-live', [req.query.profileId]));
            break;
    }
})

module.exports = app;