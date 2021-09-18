let h = process.argv[2];
let r = process.argv[3];
let R = process.argv[4];

// Объем усеченного конуса
console.log(1/3 * Math.PI * h * (R ** 2 + R * R + r ** 2));