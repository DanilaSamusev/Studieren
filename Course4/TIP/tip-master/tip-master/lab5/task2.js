const date = new Date();

console.log(`Hours: ${date.getHours()} Minutes: ${date.getMinutes()} Seconds: ${date.getSeconds()}`);

console.log(`Milliseconds since 1 Jan 1970 : ${Date.parse(date)}`);
console.log(`Seconds since 1 Jan 1970 ${Math.trunc(date.getTime() / 1000)}`);

const birthday = new Date("30 Jun 2001");
const weekdays = [
  "Sunday",
  "Monday",
  "Tuesday",
  "Wednesday",
  "Thursday",
  "Friday",
  "Saturday"
]
console.log(`There was ${weekdays[birthday.getDay()]}`)
