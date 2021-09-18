const absInitial = 893.284;

window.alert(Math.abs(absInitial));

const roundingFunction = Math.floor;

window.alert(roundingFunction(absInitial * 10) / 10);

let numbers = [];
for (let i = 0; i < 8; i++) {
  numbers.push(roundingFunction(Math.random() * 4 * 10) / 10);
}
window.alert(`numbers = ${numbers} \n max = ${Math.max(...numbers)}`);
