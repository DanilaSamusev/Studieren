const R = Array(4);
const strings = ['k', 'm', 's'];
for (let [index, value] of strings.entries()) {
  R[index] = value;
}
R.push(3);
R.unshift("class", "ts", "js")

console.log(R);


let secArray = Array(5);
for (let i = 0; i < 5; i++) {
  let B = Array(8);
  for (let j = 0; j < 8; j++) {
    B[j] = Math.random();
  }
  if (i % 2) {
    secArray[i] = B.sort()
    continue;
  }
  secArray[i] = B;
}

console.log(secArray);


let thirdArray = Array(8);
for (let i = 0; i < 8; i++) {
  let C = Array(7);
  for (let j = 0; j < 7; j++) {
    C[j] = [Math.random().toString(), "aaa"][Math.round(Math.random())];
  }
  thirdArray[i] = C;
}
thirdArray = thirdArray.reverse();
console.log(thirdArray);


let fourthArray = Array(6);
for (let i = 0; i < 6; i++) {
  let inner = Array(5);
  for (let j = 0; j < 5; j++) {
    inner[j] = `${i}sock${j}`;
  }
  fourthArray[i] = inner;
}

fourthArray.unshift(["new", "new1", "new2", "new3", "new4"])
for (let k = 0; k < 3; k++) { fourthArray.pop(); }

console.log(fourthArray);
