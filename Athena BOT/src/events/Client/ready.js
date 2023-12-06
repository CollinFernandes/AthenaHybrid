const { log } = require("../../functions");
const ExtendedClient = require('../../class/ExtendedClient');
const { ActivityType } = require("discord.js");
const { DownloadCosmetics } = require("../../class/Utils");
const config = require("../../config");

module.exports = {
    event: 'ready',
    once: true,
    /**
     * 
     * @param {ExtendedClient} _ 
     * @param {import('discord.js').Client<true>} client 
     * @returns 
     */
    run: (_, client) => {

        log('Logged in as: ' + client.user.tag, 'done');
        client.user.setPresence({
            activities: [{ name: `Athena Hybrid`, type: ActivityType.Watching }],
            status: 'dnd',
        });
        DownloadCosmetics();
        config.cosmetics = require('../../../temp/cosmetics.json')
    }
};