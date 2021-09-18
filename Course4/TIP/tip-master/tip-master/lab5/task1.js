let numbers = process.argv.slice(2).map(x => Math.tan(x / 2)).sort();

console.log(`Sorted array: ${numbers}`);