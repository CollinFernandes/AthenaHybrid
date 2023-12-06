const { ModalSubmitInteraction, ChatInputCommandInteraction, SlashCommandBuilder, EmbedBuilder, ButtonStyle, ButtonBuilder, ComponentType, ActionRowBuilder, Embed, ModalBuilder, TextInputBuilder, TextInputStyle, InteractionResponse } = require('discord.js');
const { Client, Enums } = require('fnbr');
const fs = require('fs').promises;
const { existsSync, readFileSync, writeFileSync } = require('fs')
let BotClient = null;
let BotAuth = null;
const ExtendedClient = require('../../class/ExtendedClient');
const config = require('../../config');

module.exports = {
    customId: 'newaccountmodal',
    /**
     * 
     * @param {ExtendedClient} client 
     * @param {ModalSubmitInteraction} interaction 
     */
    run: async (client, interaction) => {
        const res = new EmbedBuilder()
        .setColor('#4b16ff')
        .setDescription(`*${interaction.user} | Creating BOT...*`);
        interaction.reply({embeds: [res]})
        const filePath = `${process.cwd()}/temp/accounts/${interaction.user.id}.json`;
        const enteredAuthCode = interaction.fields.getTextInputValue('newaccountid');
        try {
            if (config.bots[buttonInteraction.user.id] == undefined) {
                BotClient = new Client({
                    "defaultStatus": "Lean Bot by FrostChanger.de",
                    "platform": "WIN",
                    "cachePresences": false,
                    "auth": {
                        "authorizationCode": enteredAuthCode,
                    },
                    "partyConfig": {
                        "privacy": Enums.PartyPrivacy.PRIVATE,
                        "joinConfirmation": false,
                        "joinability": "INVITE_AND_FORMER",
                        "maxSize": 16,
                        "chatEnabled": true
                    },
                    "debug": false
                });
    
                BotClient.on('ready', async () => {
                    BotClient.isReady = true;
                    config.bots[interaction.user.id] = BotClient;
                    BotClient.user.displayName = BotClient.user.displayName;
    
                    // Respond to the user
                    const creationSuccess = new EmbedBuilder()
                        .setColor('#4b16ff')
                        .setDescription(`*${interaction.user} | Started your BOT as \`\`${BotClient.user.displayName}\`\`*`);
                    interaction.editReply({ embeds: [creationSuccess] });
    
                    var data = null;
                    if (existsSync(`${process.cwd()}/temp/accounts/${buttonInteraction.user.id}.json`))
                        data = JSON.parse(readFileSync(`${process.cwd()}/temp/accounts/${buttonInteraction.user.id}.json`))
                    else
                        data = JSON.parse(JSON.stringify({}))
                    data[BotClient.user.displayName] = BotAuth;
                    writeFileSync(`${process.cwd()}/temp/accounts/${buttonInteraction.user.id}.json`, JSON.stringify(data, null, 2));
                });
    
                BotClient.on('deviceauth:created', (da) => {
                    BotAuth = da;
                })
    
                BotClient.on('friend:request', async (req) => {
                    res.setDescription(`*${interaction.user} | friend request from \`\`${req.displayName}\`\`*`)
                    const accept = new ButtonBuilder()
                    .setCustomId('acceptfreq')
                    .setLabel('Accept')
                    .setStyle(ButtonStyle.Success)
    
                    const decline = new ButtonBuilder()
                    .setCustomId('declinefreq')
                    .setLabel('Decline')
                    .setStyle(ButtonStyle.Danger)
    
                    const components = new ActionRowBuilder()
                    .addComponents(accept, decline);
    
                    const collector = (await reply).createMessageComponentCollector({ componentType: ComponentType.Button });
                    collector.on('collect', async (interaction1) => {
                        if (interaction1.customId == 'acceptfreq') {
                            req.accept();
                            res.setDescription(`*${interaction1.user} | accepted \`\`${req.displayName}\`\`'s friend request*`)
                            interaction1.reply({embeds: [res], ephemeral: true})
                        } else if (interaction1.customId == 'declinefreq') {
                            req.decline();
                            res.setDescription(`*${interaction1.user} | declined \`\`${req.displayName}\`\`'s friend request*`)
                            interaction1.reply({embeds: [res], ephemeral: true})
                        }
                    })
                    interaction.followUp({embeds: [res], ephemeral: true, components: [components]})
                })
    
                BotClient.on('party:invite', async (req) => {
                    res.setDescription(`*${interaction.user} | party invite from \`\`${req.sender.displayName}\`\`*`)
                    const accept = new ButtonBuilder()
                    .setCustomId('acceptpinv')
                    .setLabel('Accept')
                    .setStyle(ButtonStyle.Success)
    
                    const decline = new ButtonBuilder()
                    .setCustomId('declinepinv')
                    .setLabel('Decline')
                    .setStyle(ButtonStyle.Danger)
    
                    const components = new ActionRowBuilder()
                    .addComponents(accept, decline);
    
                    const collector = (await reply).createMessageComponentCollector({ componentType: ComponentType.Button });
                    collector.on('collect', async (interaction1) => {
                        if (interaction1.customId == 'acceptpinv') {
                            req.accept();
                            res.setDescription(`*${interaction1.user} | accepted \`\`${req.sender.displayName}\`\`'s party invite*`)
                            interaction1.reply({embeds: [res], ephemeral: true})
                        } else if (interaction1.customId == 'declinepinv') {
                            req.decline();
                            res.setDescription(`*${interaction1.user} | declined \`\`${req.sender.displayName}\`\`'s party invite*`)
                            interaction1.reply({embeds: [res], ephemeral: true})
                        }
                    })
                    interaction.followUp({embeds: [res], ephemeral: true, components: [components]})
                })
    
                BotClient.login();
            } else {
                res.setDescription(`*${buttonInteraction.user} | You already have a running BOT called \`\`${config.bots[buttonInteraction.user.id].user.displayName}\`\`!*`)
                interaction.reply({embeds: [res]})
            }
        } catch (err) {
            const failLogin = new EmbedBuilder()
                .setColor('#ffffff')
                .setTitle(`You entered an invalid or expired authorization code. Support: https://discord.gg/frostchanger`);
            await interaction.editReply({embeds: [failLogin]});
        }
    }
};