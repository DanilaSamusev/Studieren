let date = new Date(process.argv[2]);


const seasons = {
  "winter": [12, 1, 2],
  "spring": [3, 4, 5],
  "summer": [6, 7, 8],
  "autumn": [9, 10, 11]
}

for (let [season, range] of Object.entries(seasons)) {
  if (range.includes(date.getMonth() + 1)) {
    console.log(`It's ${season} time!`);
    break;
  }
}

console.log(`Is year leap?: ${new Date(date.getFullYear(), 1, 29).getMonth() === 1}`)

