let numbers = Array.from(process.argv.slice(2)).map(item => parseFloat(item));


let resultTernary = 0;
let resultBinary = 0;
for (let [index, value] of numbers.entries()) {
  if (!(index % 3)) {
    resultTernary += value;
  }
  if (!(index % 2)) {
    resultBinary += value;
  }
}

console.log(`СЭКЗ = ${resultTernary}`)
console.log(`СЧЭ = ${resultBinary}`)
