const userName = document.querySelector('#name');
const userModel = document.querySelector('#model');
const userProduct = document.querySelector('#product');
const userPhone = document.querySelector('#phone');
const userDate = document.querySelector('#date');
const sender = document.querySelector('#sender')
const btn = document.querySelector('#btn');
let data = {}; // порожній об'єкт для збереження даних
let count = 0; // змінна для відстежування кількості елементів у масиві

btn.addEventListener('click', () => {
  let name = userName.value;
  let model = userModel.value;
  let product = userProduct.value;
  let date = userDate.value;
  let phone = userPhone.value;
  let senders = sender.value;


  if (name === '') {
    alert("Введіть ім'я клієнта");
    return; 
  }
  else if (phone === '') {
    alert ("Введіть номер або інші дані клієнта")
    return;
  }
  else if (model === '') {
    alert ("Введіть модель пристрою")
    return;
  }
  else if (product === '') {
    alert ("Яку запчастину ви замовляєте?")
    return;
  }
  else if (date === '') {
    alert ("Коли запчастина прибуде?")
    return;
  }

  console.log(senders);
  // додаю нову інфу в об'єкт з ключем, що починається з 0
  data[count] = {
    name: name,
    phone: phone,
    model: model,
    product: product,
    date: date,
    sender: senders,
  };

  count++; // збільшуємо значення count після додавання нового елемента

  console.log(data); // виведжу масив в консолі для перевірки

  createInfo();
});

function createInfo() {
  const userInfo = document.querySelector('.userInfo');
  let tableBody = '';

  // проходимось по об'єкту з даними та створюємо новий рядок таблички для кожного елемента
  for (let key in data) {
    tableBody += `
      <tr>
        <td>${data[key].sender}</td>
        <td>${data[key].name}</td>
        <td>${data[key].phone}</td>
        <td>${data[key].model}</td>
        <td>${data[key].product}</td>
        <td>${data[key].date}</td>
        <td>
          <label class="toggleButton">
            <input type="checkbox" id="status${key}">
            <div>
              <svg viewBox="0 0 44 44">
                <path d="M14,24 L21,31 L39.7428882,11.5937758 C35.2809627,6.53125861 30.0333333,4 24,4 C12.95,4 4,12.95 4,24 C4,35.05 12.95,44 24,44 C35.05,44 44,35.05 44,24 C44,19.3 42.5809627,15.1645919 39.7428882,11.5937758" transform="translate(-2.000000, -2.000000)"></path>
              </svg>
            </div>
          </label>
        </td>
      </tr>
    `;
  }
  

  // вставляємо створений HTML з рядками таблички в таблицю
  userInfo.innerHTML = `
    <table>
      <thead>
        <tr>
          <th>Senders</th>
          <th>Client names</th>
          <th>Phone numbers</th>
          <th>Device models</th>
          <th>Expected products</th>
          <th>Date of arrival</th>
          <th>Status</th>
        </tr>
      </thead>
      <tbody>
        ${tableBody}
      </tbody>
    </table>
  `;
}
