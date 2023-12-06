const { ChannelType, Message } = require("discord.js");
const config = require("../../config");
const { log } = require("../../functions");
const ExtendedClient = require("../../class/ExtendedClient");

module.exports = {
  event: "guildMemberAdd",
  /**
   *
   * @param {ExtendedClient} client
   * @param {Message<true>} message
   * @returns
   */
  run: async (client, message) => {
    client.channels.fetch('1179057229199056916').then(voice => {
        var memberCount = voice.guild.memberCount;
        voice.setName(`Members: ${memberCount}`)
            .catch(console.error);
    })
  },
};
