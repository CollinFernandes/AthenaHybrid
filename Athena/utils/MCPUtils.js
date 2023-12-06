const axios = require('axios')
const fs = require('fs')
ServiceConfig = require(`../config`);
const random = require('random')

function checkProfile(accountId) {
    if (!fs.existsSync(`${config.dir}/trash/profiles/${accountId}.json`)) {
        createProfile(accountId);
    }
}

function createProfile(accountId) {
    fs.copyFileSync(`${ServiceConfig.dir}/trash/templates/template.json`, `${ServiceConfig.dir}/trash/profiles/${accountId}.json`)
}

function loadProfileConfig(accountId) {
    return JSON.parse(fs.readFileSync(`${ServiceConfig.dir}/trash/profiles/${accountId}.json`))
}

function loadProfile(profileId, accountId) {
    return JSON.parse(fs.readFileSync(`${ServiceConfig.dir}/trash/templates/profile_${profileId}.json`))
}

function saveProfileConfig(dir, accountId, data) {
    fs.writeFileSync(`${dir}/trash/profiles/${accountId}.json`, JSON.stringify(data, null, 2))
}

/// CREDITS TU AURORA AND NEONITE ///
function createResponse(profileData, profileId, rvn) {
    return {
      profileRevision: rvn ? rvn - 0 + (1 - 0) : 1 || 1,
      profileId: profileId,
      profileChangesBaseRevision: Number(rvn) || 1,
      profileChanges: [
        {
          changeType: 'fullProfileUpdate',
          profile: profileData
        }
      ],
      profileCommandRevision: rvn ? rvn - 0 + (1 - 0) : 1 || 1,
      serverTime: new Date().toISOString(),
      responseVersion: 1
    };
}

function createError(errorCode, errorMessage, numericErrorCode, originatingService, intent, messageVars) {
    return {
        errorCode: errorCode,
        errorMessage: errorMessage,
        numericErrorCode: numericErrorCode,
        originatingService: originatingService,
        messageVars: messageVars || undefined,
        intent: intent || 'prod'
    };
}

function createCreative(accountId, profile) {
    profile.accountId = accountId;
    profile.created = new Date().toISOString();
    profile.updated = new Date().toISOString();
    profile.profileId = 'creative';

    return profile
}

function createCommonCore(config, accountId, profile) {
    profile._id = accountId;
    profile.accountId = accountId;
    profile.created = new Date().toISOString();
    profile.updated = new Date().toISOString();
    profile.profileId = 'athena';
    profile.items['Currency:MtxPurchased'].quantity = config.vbucks;
    profile.items['Currency:MtxPurchased'];
    profile.stats.attributes.mtx_affiliate = 'GKI';

    return profile;
}

function createCommonPublic(accountId, profile) {
    profile.accountId = accountId;
    profile.created = new Date().toISOString();
    profile.updated = new Date().toISOString();
    profile.profileId = 'athena';

    return profile;
}

function createCollections(accountId, profile) {
    profile.accountId = accountId;
    profile.created = new Date().toISOString();
    profile.updated = new Date().toISOString();
    profile.profileId = 'athena';

    return profile;
}

function createAthena(config, accountId, profile) {
    //#region standard Shit
    profile._id = accountId;
    profile.accountId = accountId;
    profile.version = 'Athena Hybrid'
    profile.created = new Date().toISOString();
    profile.updated = new Date().toISOString();
    profile.profileId = 'athena';
    //#endregion
    //#region defining Locker
    var locker = profile.items.sandbox_loadout.attributes.locker_slots_data.slots;
    //#endregion
    //#region setting Locker
    locker.MusicPack.items[0] = config.MusicPack.ID;
    locker.MusicPack.activeVariants = config.MusicPack.Variants;
    locker.Character.items[0] = config.Character.ID;
    locker.Character.activeVariants = config.Character.Variants;
    locker.Backpack.items[0] = config.Backpack.ID;
    locker.Backpack.activeVariants = config.Backpack.Variants;
    locker.SkyDiveContrail.items[0] = config.SkyDiveContrail.ID;
    locker.SkyDiveContrail.activeVariants = config.SkyDiveContrail.Variants;
    locker.Dance.items = config.Dance.ID;
    locker.Dance.activeVariants = config.Dance.Variants;
    locker.ItemWrap.items = config.ItemWrap.ID;
    locker.ItemWrap.activeVariants = config.ItemWrap.Variants;
    locker.Pickaxe.items[0] = config.Pickaxe.ID;
    locker.Pickaxe.activeVariants = config.Pickaxe.Variants;
    locker.LoadingScreen.items[0] = config.LoadingScreen.ID;
    locker.LoadingScreen.activeVariants = config.LoadingScreen.Variants;
    locker.Glider.items[0] = config.Glider.ID;
    locker.Glider.activeVariants = config.Glider.Variants;
    profile.items.sandbox_loadout.attributes.banner_icon_template = config.BannerIconTemplate;
    profile.items.sandbox_loadout.attributes.banner_color_template = config.BannerColorTemplate;
    //#endregion
    //#region defining Stats
    var stats = profile.stats.attributes
    //#endregion
    //#region setting Stats
    stats.book_level = parseInt(config.level)
    stats.book_purchased = true;
    stats.lifetime_wins = random.int(1337, 696969)
    stats.level = parseInt(config.level, 10)
    stats.battlestars = parseInt(config.battlestars);
    stats.battlestars_season_total = parseInt(config.battlestars);
    stats.alien_style_points = parseInt(config.alien_style_points);
    stats.accountLevel = parseInt(config.level);
    stats.season_num = ServiceConfig.seasonNumber;

    profile.stats.attributes = stats;
    //#endregion
    //#region defining Items
    var items = profile.items;
    //#endregion
    for (var item of Object.keys(config.favorites)) {
        items[item['id']].attributes.favorite = true;
    }
    return profile
}

module.exports = {
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
}