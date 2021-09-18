let string = process.argv[2];
let k = process.argv[3];

console.log(`Is ${k} symbol of ${string} alpha: ${RegExp(/[a-zA-Z]/, 'u').test(string[k])}`);
console.log(`Is sum of numbers in ${string} even: ${!(Array.from(string).filter(item => !isNaN(parseInt(item))).map(item => parseInt(item)).reduce((sum, i) => sum + i) % 2)}`)