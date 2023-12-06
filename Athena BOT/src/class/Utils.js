const { writeFileSync, readFileSync, existsSync, mkdirSync } = require('fs');
const fetch = require('node-fetch');

async function DownloadCosmetics() {
    const url = 'https://fortnite-api.com/v2/cosmetics/br';

    const response = await fetch(url);
    const json = await response.json()
    .catch(e => this.logger.error(e.message));

    const file_path = `${process.cwd()}/temp/cosmetics.json`;
    await writeFileSync(file_path, JSON.stringify(json?.data, null, 2));
}

async function FindCosmeticByType(cosmetics, query, type) {
    return cosmetics.find((cosmetic) => (cosmetic.id.toLowerCase() === query.toLowerCase() || cosmetic.name.toLowerCase() === query.toLowerCase()) && cosmetic.type.value === type);
}

async function FindCosmetic(cosmetics, query) {
    return cosmetics.find((cosmetic) => (cosmetic.id.toLowerCase() === query.toLowerCase() || cosmetic.name.toLowerCase() === query.toLowerCase()));
}

module.exports = { DownloadCosmetics, FindCosmetic, FindCosmeticByType  }