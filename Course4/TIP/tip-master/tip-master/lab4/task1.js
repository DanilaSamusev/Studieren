let lang = process.argv[2];
let msw = [];

if (lang === "рус") {
  msw = [
    "Понедельник",
    "Вторник",
    "Среда",
    "Четверг",
    "Пятница",
    "Суббота",
    "Воскресенье"
  ];
} else if(lang === "анг") {
  msw = [
    "Monday",
    "Tuesday",
    "Wednesday",
    "Thursday",
    "Friday",
    "Sunday",
    "Saturday"
  ];
} else if (lang === "бел") {
  msw = [
    "Панядзелак",
    "Ауторак",
    "Серада",
    "Чацвер",
    "Пятница",
    "Субота",
    "Нядзеля",
  ];
} else if (lang === "нем") {
  msw = [
    "Montag",
    "Dienstag",
    "Mittwoch",
    "Donnerstag",
    "Freitag",
    "Samstag",
    "Sonntag"
  ];
}

console.log(msw);