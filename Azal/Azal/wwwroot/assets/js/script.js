const nightBtn = document.getElementById('night')
const light = document.querySelector('.light')
const body = document.querySelector('body')
const footer = document.querySelector('footer')
const socialBtn = document.querySelectorAll('.socialBtn')
const directions = document.querySelectorAll('.direct')
const usefulLink = document.querySelectorAll('#useful')
const moreBtn = document.querySelectorAll('.moreBtn')
const usefulHead = document.querySelectorAll('.h2')
const labels = document.querySelectorAll('.label')
const tabs = document.querySelectorAll('.tabs button')
const dateBtn = document.querySelector('#dateBtn')





function tabsChange() {
    const tabs = document.querySelectorAll('.tab');

    for (let tab of tabs) {
        tab.addEventListener('click', function () {
            for (t of tabs) {
                t.classList.remove('active');
            }
            tab.classList.add('active');
        })
    }
}
tabsChange();

nightBtn.addEventListener('click', function () {
    if (light.src.includes('light')) {
        nightMode();
    } else {
        defaultMode();
    }
})

function nightMode() {
    light.src = 'assets/img/moon.svg'
    body.classList.add('bg-black')
    footer.classList.remove('bg-[#01357e]')
    for (let btn of socialBtn) {
        btn.classList.replace('bg-white', 'bg-[#1f2022]')
        btn.classList.replace('text-[#01357e]', 'text-white')
    }
    // for(let direct of directions) {
    //     direct.classList.add('text-white')
    // }
    for (let useful of usefulLink) {
        useful.classList.add('bg-[#1f2022]');
        useful.classList.remove('border')
    }
    for (let btnMore of moreBtn) {
        btnMore.classList.replace('text-[#40b7de]', 'text-white')
    }
    for (let head of usefulHead) {
        head.classList.add('text-white')
    }



}

function defaultMode() {
    light.src = 'assets/img/light.svg'
    body.classList.remove('bg-black')
    footer.classList.add('bg-[#01357e]')
    for (let btn of socialBtn) {
        btn.classList.replace('bg-[#1f2022]', 'bg-white')
        btn.classList.replace('text-white', 'text-[#01357e]')
    }
    // for(let direct of directions) {
    //     direct.classList.remove('text-white')
    // } 
    for (let useful of usefulLink) {
        useful.classList.remove('bg-[#1f2022]');
        useful.classList.add('border')
    }
    for (let btnMore of moreBtn) {
        btnMore.classList.replace('text-white', 'text-[#40b7de]')
    }
    for (let head of usefulHead) {
        head.classList.remove('text-white')
    }
}


//function filterOptions(input, dropdown, destinations) {
//    const value = input.value.toLowerCase();
//    const filteredDestinations = destinations.filter(destination =>
//        destination.city.toLowerCase().includes(value) ||
//        destination.code.toLowerCase().includes(value)
//    );

//    dropdown.innerHTML = "";
//    dropdown.classList.add('show');

//    filteredDestinations.forEach(destination => {
//        const option = document.createElement('div');
//        option.className = 'option cursor-pointer hover:bg-[#eeeeee80]';
//        option.innerHTML = `
//            <button class="p-[16px] flex items-center text-[14px] font-semibold leading-[20px] w-full">
//                <div class="flex items-center w-full">
//                    <svg width="20" height="20" viewBox="0 0 20 20" fill="currentColor" xmlns="http://www.w3.org/2000/svg" class="text-[#CDD5DF] mr-[10px]">
//                        <path d="M5.19593 2.6236C5.0576 2.62532 4.91992 2.66184 4.79554 2.73184C4.32471 2.99725 4.22501 3.63237 4.59209 4.02904L8.09307 7.8124L4.88831 9.21296L2.91484 8.05491C2.67109 7.912 2.37143 7.90298 2.11976 8.03131C1.68518 8.25215 1.53424 8.79964 1.79424 9.21214L2.91078 10.9838C3.53161 11.9688 4.77949 12.3521 5.84616 11.8855L17.4868 6.79108C18.2014 6.47858 18.5272 5.64531 18.2151 4.93073C17.9022 4.21615 17.0694 3.88988 16.3548 4.20238L11.9782 6.11481L5.59876 2.72126C5.47272 2.65438 5.33427 2.62188 5.19593 2.6236ZM3.12481 15.8332C3.04199 15.8321 2.95976 15.8474 2.8829 15.8782C2.80605 15.9091 2.7361 15.955 2.67712 16.0131C2.61814 16.0713 2.5713 16.1406 2.53933 16.217C2.50737 16.2934 2.4909 16.3754 2.4909 16.4582C2.4909 16.5411 2.50737 16.6231 2.53933 16.6995C2.5713 16.7759 2.61814 16.8452 2.67712 16.9033C2.7361 16.9615 2.80605 17.0073 2.8829 17.0382C2.95976 17.0691 3.04199 17.0844 3.12481 17.0832H16.8748C16.9576 17.0844 17.0399 17.0691 17.1167 17.0382C17.1936 17.0073 17.2635 16.9615 17.3225 16.9033C17.3815 16.8452 17.4283 16.7759 17.4603 16.6995C17.4922 16.6231 17.5087 16.5411 17.5087 16.4582C17.5087 16.3754 17.4922 16.2934 17.4603 16.217C17.4283 16.1406 17.3815 16.0713 17.3225 16.0131C17.2635 15.955 17.1936 15.9091 17.1167 15.8782C17.0399 15.8474 16.9576 15.8321 16.8748 15.8332H3.12481Z"></path>
//                    </svg>
//                    <span class="flex-1 text-left">${destination.city}, ${destination.country}</span>
//                    <span class="text-[#6E7583]">${destination.code}</span>
//                </div>
//            </button>
//        `;
//        dropdown.appendChild(option);

//        option.querySelector('button').addEventListener('click', () => {
//            input.value = `${destination.city}, ${destination.country}`;
//            dropdown.classList.remove('show');
//        });
//    });
//}
function inputValueCheck() {
    const inputs = document.querySelectorAll('.from');
    
    for (let input of inputs) {
        const label = input.nextElementSibling;
        const border = input.closest('.labell');
        const dropdown = input.closest('.labell').nextElementSibling;

        input.addEventListener('focus', function () {
            label.classList.add('focused');
            border.style.borderColor = '#37A6DB';
            dropdown.classList.add('show');
            //filterOptions(input, dropdown); // İlk dəfə göstərmək üçün
        });

        input.addEventListener('blur', function () {
            setTimeout(() => {
                dropdown.classList.remove('show');
                if (input.value === '') {
                    label.classList.remove('focused');
                    border.style.borderColor = '#C52F5C';
                } else {
                    border.style.borderColor = '#DBE0E4'; // Default boz rəng
                }
            }, 200); // Bu gecikmə, dropdown seçimlərindəki klik hadisəsinin qeydiyyata alınmasına imkan verir
        });

        input.addEventListener('input', function (event) {
            const value = event.target.value;

            if (value !== '') {
                label.classList.add('focused');
                border.style.borderColor = '#37A6DB';
                dropdown.classList.add('show');
                filterOptions(input, dropdown);
            } else {
                label.classList.add('focused');
                border.style.borderColor = '#37A6DB';
                filterOptions(input, dropdown); // Boş olduqda da göstərmək üçün
            }
        });

        dropdown.querySelectorAll('.option button').forEach(button => {
            button.addEventListener('click', function () {
                const countryName = this.querySelector('.flex-1').textContent;
                input.value = countryName;
                dropdown.classList.remove('show');
            });
        });
    }
}

function setupInputs() {
    const inputs = document.querySelectorAll('.from');
    inputs.forEach(input => {
        const dropdown = input.closest('.labell').nextElementSibling;
        input.addEventListener('input', function () {
            filterOptions(input, dropdown, destinations);
        });
        const clearBtn = input.parentElement.querySelector('.clear-btn');
        const airportCodeSpan = input.parentElement.querySelector('.airport-code');
        const label = input.nextElementSibling;
        const border = input.closest('.labell');

        function updateInputState() {
            if (input.value) {
                label.classList.add('focused');
                border.style.borderColor = '#37A6DB';
                airportCodeSpan.classList.add('hidden');
                clearBtn.classList.remove('hidden');
            } else {
                label.classList.remove('focused');
                border.style.borderColor = '#DBE0E4';
                airportCodeSpan.classList.remove('hidden');
                clearBtn.classList.add('hidden');
            }
        }

        input.addEventListener('input', updateInputState);
        input.addEventListener('focus', () => {
            border.style.borderColor = '#37A6DB';
            label.classList.add('focused');
        });
        input.addEventListener('blur', () => {
            if (!input.value) {
                border.style.borderColor = '#DBE0E4';
            }
        });

        input.parentElement.addEventListener('mouseenter', () => {
            if (input.value) {
                airportCodeSpan.classList.add('hidden');
                clearBtn.classList.remove('hidden');
            }
        });

        input.parentElement.addEventListener('mouseleave', () => {
            if (input.value) {
                clearBtn.classList.add('hidden');
                airportCodeSpan.classList.remove('hidden');
            }
        });

        clearBtn.addEventListener('click', (e) => {
            e.preventDefault();
            input.value = '';
            updateInputState();
            border.style.borderColor = '#DBE0E4';
        });

        // İlkin vəziyyəti yoxla
        updateInputState();
    });
}

// Funksiyanı çağır
setupInputs();

function setupChangeButton() {
    const changeBtn = document.getElementById('changeBtn');
    const inputs = document.querySelectorAll('.from');

    changeBtn.addEventListener('click', function () {
        if (inputs[0].value !== '' && inputs[1].value !== '') {
            const tempValue = inputs[0].value;
            inputs[0].value = inputs[1].value;
            inputs[1].value = tempValue;
        }
    });
}

dateBtn.addEventListener('click', function () {
    const nextDiv = dateBtn.nextElementSibling.nextElementSibling;;
    nextDiv.classList.toggle('hidden')
});

document.addEventListener('DOMContentLoaded', function () {
    inputValueCheck();
    setupChangeButton();

    const buttons = document.querySelectorAll('#monthBtn button');

    buttons.forEach((button, index) => {
        button.addEventListener('click', () => {
            buttons.forEach(btn => {
                btn.classList.remove('text-[#2C8DC7]', 'font-semibold', 'active');
                btn.classList.add('text-black');
                if (btn.querySelector('.line')) {
                    btn.querySelector('.line').remove();
                }
            });

            button.classList.add('text-[#2C8DC7]', 'font-semibold', 'active');
            button.classList.remove('text-black');
            if (!button.querySelector('.line')) {
                const lineDiv = document.createElement('div');
                lineDiv.className = 'line absolute w-[4px] h-[52px] bg-[#2C8DC7] left-0';
                button.prepend(lineDiv);
            }

            if (index + 1 < buttons.length) {
                const nextButton = buttons[index + 1];
                nextButton.classList.add('text-[#2C8DC7]', 'font-semibold', 'active');
                nextButton.classList.remove('text-black');
                if (!nextButton.querySelector('.line')) {
                    const lineDiv = document.createElement('div');
                    lineDiv.className = 'line absolute w-[4px] h-[32px] bg-[#2C8DC7] left-0';
                    nextButton.prepend(lineDiv);
                }
            }
        });
    });



    const monthButtons = document.querySelectorAll('#monthBtn button');
    const el1 = document.getElementById('el1');
    const el2 = document.getElementById('el2');
    const dateBtn = document.getElementById('dateBtn');
    const commutingDiv = document.querySelector('.commuting');
    const departureSpan = commutingDiv.querySelector('.departure');
    const landingSpan = commutingDiv.querySelector('.landing');
    const oneWayBtn = document.getElementById('oneWayBtn');
    const kalendarDiv = document.querySelector('.kalendar');

    const azMonths = [
        "Yanvar", "Fevral", "Mart", "Aprel", "May", "İyun",
        "İyul", "Avqust", "Sentyabr", "Oktyabr", "Noyabr", "Dekabr"
    ];
    const today = new Date();
    today.setHours(0, 0, 0, 0);

    let selectedDates = [];
    let currentMonths = [6, 7];
    let isOneWay = false;

    monthButtons.forEach((button, index) => {
        button.addEventListener('click', () => {
            updateActiveMonth(index);
            renderCalendars(index, index + 1);
        });
    });

    function updateActiveMonth(index) {
        monthButtons.forEach((btn, i) => {
            btn.classList.toggle('active', i === index);
            if (i === index) {
                const line = document.createElement('div');
                line.className = 'line absolute w-[4px] h-[32px] bg-[#2C8DC7] left-0';
                btn.appendChild(line);
            } else {
                const line = btn.querySelector('.line');
                if (line) line.remove();
            }
        });
    }

    function renderCalendars(month1 = 0, month2 = 1) {
        currentMonths = [month1, month2];
        renderCalendar(el1, month1);
        renderCalendar(el2, month2);
    }

    function renderCalendar(element, monthIndex) {
        const date = new Date(2024, monthIndex + 7, 1);
        const year = date.getFullYear();
        const month = date.getMonth();
        const firstDay = new Date(year, month, 1);
        const lastDay = new Date(year, month + 1, 0);

        let table = '<table class="w-full">';
        table += '<tr><th colspan="7" class="text-[16px] font-bold py-[16px]">' +
            azMonths[month] + ' ' + year + '</th></tr>';
        table += '<tr class="text-[14px] font-medium text-[#9CA3AF]">' +
            '<th>BE</th><th>ÇA</th><th>Ç</th><th>CA</th><th>C</th><th>Ş</th><th>B</th></tr>';

        let day = 1;
        const firstDayIndex = (firstDay.getDay() + 6) % 7;

        for (let i = 0; i < 6; i++) {
            table += '<tr>';
            for (let j = 0; j < 7; j++) {
                if (i === 0 && j < firstDayIndex) {
                    table += '<td></td>';
                } else if (day > lastDay.getDate()) {
                    table += '<td></td>';
                } else {
                    const currentDate = new Date(year, month, day);
                    const isSelected = selectedDates.some(d => d.toDateString() === currentDate.toDateString());
                    const isPastDate = currentDate < today;

                    let cellClass = 'text-[13px] leading-[20px] size-[40px] font-medium text-center py-[8px] ';
                    if (isSelected) {
                        cellClass += 'bg-[#2C8DC7] text-white rounded-[6px] ';
                    }
                    if (isPastDate) {
                        cellClass += 'text-gray-300 cursor-not-allowed ';
                    } else {
                        cellClass += 'cursor-pointer ';
                    }

                    table += `<td class="${cellClass}" 
                                  ${!isPastDate ? `onclick="selectDate(${year}, ${month}, ${day})"` : ''}>${day}</td>`;
                    day++;
                }
            }
            table += '</tr>';
            if (day > lastDay.getDate()) break;
        }
        table += '</table>';
        element.innerHTML = table;
    }


    

    function updateSelectedDates() {


        if (selectedDates.length > 0) {
            const [departureDate, returnDate] = selectedDates;
            if (departureDate) {
                departureSpan.textContent = formatDateString(departureDate);
                oneWayBtn.disabled = false;
                oneWayBtn.classList.remove('opacity-50', 'cursor-not-allowed');
            }
            if (returnDate) {
                landingSpan.textContent = isOneWay ? '-' : formatDateString(returnDate);
            } else {
                landingSpan.textContent = isOneWay ? '-' : '';
            }
            dateBtn.classList.add('hidden');
            commutingDiv.classList.remove('hidden');

            if (selectedDates.length === 2 || isOneWay) {
                kalendarDiv.classList.add('hidden');
            }

        }
    }
    document.querySelector("#searchId").addEventListener("click", function () {

        var input1 = document.querySelector(".input1")
        var departureAirportcode = document.querySelector("#departureairportcode").innerHTML
        var arrivalAirportCode = document.querySelector("#arrivalairportcode").innerHTML
        var input2 = document.querySelector(".input2")
        const [departureDate, returnDate] = selectedDates;
        var passengerCount = document.querySelector("#passengerCount").innerHTML

        var array = passengerCount.split(",")
        const data = {
            DepartureAirport: input1.value,
            ArrivalAirport: input2.value,
            DepartureAirportCode: departureAirportcode,
            ArrivalAirportCode: arrivalAirportCode,
            Count: parseInt(array[0]),
            TicketType: array[1],
            DepatureDate: departureDate,
            ArrivalDate: returnDate
        }
        //axios.post(`/ticket/search`, data).then(res => window.location.href = "/ticket").catch(error => console.log(error))
        //axios.post('/ticket/search', data)
        //    .then(res, count => {
        //        console.log(count)
        //        const ids = res.data; // This should be a list of IDs
        //        if (ids.length > 0) {
        //            const queryString = new URLSearchParams({ ids: ids.join(',') }).toString();

        //            window.location.href = `/ticket/index?${queryString}`;
        //        } else {
        //            // Handle the case where no flights were found, if needed
        //            window.location.href = `/ticket/notFound`;
        //            console.log('No flights found.');
        //        }
        //    })
        //    .catch(error => console.log(error));


        //window.location.href = "/ticket"




        axios.post('/ticket/search', data)
            .then(res => {
                const result = res.data; // Burada serverdən gələn cavabı saxlayırıq
                const count = result.count; // Count dəyərini alırıq
                const ids = result.flightIds; // FlightIds siyahısını alırıq

                console.log('Passenger count:', count); // Count dəyərini console-a yazırıq

                if (ids.length > 0)
                {
                   
                    const queryString = new URLSearchParams({ ids: ids.join(',') }).toString();
                    window.location.href = `/ticket/index?${queryString}&count=${count}`;
                }
                else {
                    // Uçuş tapılmadığında nə edəcəyinizi idarə edin
                    window.location.href = `/ticket/notFound`;
                    console.log('No flights found.');
                }
            })
            .catch(error => console.log(error));
    }),


        window.selectDate = function (year, month, day) {
            const selectedDate = new Date(Date.UTC(year, month, day)); // UTC formatında tarix yaradırıq

            // Keçmiş tarixlərin seçilməsini əngəlləyirik
            if (selectedDate < today) {
                return;
            }

            const index = selectedDates.findIndex(d => d.toDateString() === selectedDate.toDateString());

            if (index > -1) {
                selectedDates.splice(index, 1);
            } else {
                if (isOneWay) {
                    selectedDates = [selectedDate];
                } else if (selectedDates.length < 2) {
                    selectedDates.push(selectedDate);
                } else {
                    selectedDates.shift();
                    selectedDates.push(selectedDate);
                }
            }

            selectedDates.sort((a, b) => a - b);
            updateSelectedDates();
            renderCalendars(currentMonths[0], currentMonths[1]);

            // Tarixləri backend-ə göndəririk
            if (isOneWay && selectedDates.length === 1) {
                sendDatesToBackend();
            } else if (!isOneWay && selectedDates.length === 2) {
                sendDatesToBackend();
            }
        };
    function formatDateString(date) {
        const day = date.getDate();
        const month = azMonths[date.getMonth()];
        return `${day} ${month}`;
    }


    oneWayBtn.addEventListener('click', function () {
        isOneWay = true;
        selectedDates = selectedDates.slice(0, 1);
        updateSelectedDates();
        kalendarDiv.classList.add('hidden');
    });

    commutingDiv.addEventListener('click', function (event) {
        const clickedElement = event.target.closest('button');
        if (clickedElement) {
            kalendarDiv.classList.remove('hidden');
            if (clickedElement.querySelector('.landing')) {
                isOneWay = false;
            }
        }
    });

    // İlk renderi başlat
    updateActiveMonth(0);
    renderCalendars();





});
document.addEventListener('DOMContentLoaded', function () {
    const passengerBtn = document.getElementById('passengerBtn');
    const passengerMenu = document.getElementById('passengerMenu');
    const passengerCount = document.getElementById('passengerCount');
    const ekonomBtn = document.getElementById('ekonomBtn');
    const biznesBtn = document.getElementById('biznesBtn');
    const borderLine = document.getElementById('borderLine');
    const angle = document.getElementById('angle');

    passengerBtn.addEventListener('click', function () {
        passengerMenu.classList.toggle('hidden');
        angle.classList.toggle('rotate-180');
    });

    passengerMenu.addEventListener('click', function (e) {
        // Klik edilə bilən elementin tipləri
        if (e.target.classList.contains('increase') || e.target.classList.contains('decrease')) {
            let countEl;
            if (e.target.classList.contains('increase')) {
                countEl = e.target.previousElementSibling;
                countEl.textContent = parseInt(countEl.textContent) + 1;
            } else if (e.target.classList.contains('decrease')) {
                countEl = e.target.nextElementSibling;
                if (parseInt(countEl.textContent) > 0) {
                    countEl.textContent = parseInt(countEl.textContent) - 1;
                }
            }
            updatePassengerCount();
        }
    });

    ekonomBtn.addEventListener('click', function () {
        borderLine.style.transform = 'translate(0 , 0)';
        ekonomBtn.classList.toggle('ekonom')
        updatePassengerCount();
    });

    biznesBtn.addEventListener('click', function () {
        borderLine.style.transform = 'translate(100% , 0)'
        ekonomBtn.classList.toggle('ekonom')
        updatePassengerCount();
    });

    function updatePassengerCount() {
        let total = Array.from(passengerMenu.querySelectorAll('.count')).reduce((sum, el) => sum + parseInt(el.textContent), 0);
        let classType = ekonomBtn.classList.contains('ekonom') ? 'Biznes' : 'Ekonom';
        passengerCount.textContent = `${total}, ${classType}`;
    }



});

function sendDatesToBackend() {
    if (selectedDates.length === 0) {
        console.error("Tarix seçilməyib");
        return;
    }

    const departureDate = selectedDates[0].toISOString().split('T')[0]; // YYYY-MM-DD formatında
    let returnDate = null;

    if (!isOneWay && selectedDates.length === 2) {
        returnDate = selectedDates[1].toISOString().split('T')[0];
    }

    const data = {
        departureDate: departureDate,
        returnDate: returnDate
    };

    // Backend-ə sorğu göndərmək
    fetch('/api/bookFlight', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
        .then(response => response.json())
        .then(data => {
            console.log('Uğurlu cavab:', data);
            // Burada istifadəçiyə uğurlu mesaj göstərə bilərsiniz
        })
        .catch((error) => {
            console.error('Xəta:', error);
            // Burada istifadəçiyə xəta mesajı göstərə bilərsiniz
        });
}

document.addEventListener('DOMContentLoaded', function () {
    

    fetch('/home/GetAirports') // API çağırışı
        .then(response => response.json())
        .then(data => {
            const destinations = data.$values.map(a => ({
                city: a.CityName,
                country: a.CountryName,
                code: a.AirportCode
            }));

            setupInputs(destinations); // Gələn məlumatları inputlara bağlamaq üçün
        })
        .catch(error => console.error('Error:', error));
    
});






























