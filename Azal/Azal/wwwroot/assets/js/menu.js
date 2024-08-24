const barBtn= document.getElementById("bar-btn")
const xBtn = document.getElementById("x-btn")
const dropdownBtn=document.getElementById("dropdown-btn")
const dropdown = document.getElementById("dropdown")
const headerHidden= document.getElementById("header-hidden")
const headerMain =document.getElementById("header-main")
const body = document.getElementById("body")
const navItem1 = document.getElementById("nav-item1")
const navItem2 = document.getElementById("nav-item2")
const navItem3 = document.getElementById("nav-item3")
const navItem4 = document.getElementById("nav-item4")
const navItem5 = document.getElementById("nav-item5")
const navItem6 = document.getElementById("nav-item6")
const navItem7 = document.getElementById("nav-item7")
const navItem8 = document.getElementById("nav-item8")
const navMain1 = document.getElementById("nav-main1")
const navMain2 = document.getElementById("nav-main2")
const navMain3 = document.getElementById("nav-main3")
const navMain4 = document.getElementById("nav-main4")
const navMain5 = document.getElementById("nav-main5")
const navMain6 = document.getElementById("nav-main6")
const navMain7 = document.getElementById("nav-main7")
const line1 = document.getElementById("line1")
const line2 = document.getElementById("line2")
const line3 = document.getElementById("line3")
const line4 = document.getElementById("line4")
const line5 = document.getElementById("line5")
const line6 = document.getElementById("line6")
const line7 = document.getElementById("line7")
const rezerBtn1 = document.getElementById("rezerv-btn1")
const rezerBtn2 = document.getElementById("rezerv-btn2")
const inputPlaceholder = document.querySelectorAll('.input input')[1];
const barBtn1 = document.getElementById("bar-btn1")
const barBtn2 = document.getElementById("bar-btn2")
const barBtn3 = document.getElementById("bar-btn3")
const barBtn4 = document.getElementById("bar-btn4")
const cards1 = document.getElementById("cards1")
const cards2 = document.getElementById("cards2")
const cards3 = document.getElementById("cards3")
const cards4 = document.getElementById("cards4")


barBtn.addEventListener("click",function(){
    headerHidden.style.display = "flex";
    headerMain.style.display = "none"
    body.style.overflowY = "hidden"
});

xBtn.addEventListener("click",function(){
    headerHidden.style.display = "none";
    headerMain.style.display = "flex"
    body.style.overflowY = "scroll"
});

dropdownBtn.addEventListener("click", function() {
    if (dropdown.style.display === "none") {
      dropdown.style.display = "block";
    } else {
      dropdown.style.display = "none";
    }
  });

rezerBtn1.addEventListener("click", function(){
    rezerBtn1.style.border = "1px solid #40b7de";
    rezerBtn1.style.color = "#40b7de";
    rezerBtn2.style.border = "1px solid #fff";
    rezerBtn2.style.color = "black";
    inputPlaceholder.placeholder = "Rezervasiya nömrəsi (6 simvol)";
});

rezerBtn2.addEventListener("click", function(){
    rezerBtn2.style.border = "1px solid #40b7de";
    rezerBtn2.style.color = "#40b7de";
    rezerBtn1.style.border = "1px solid #fff";
    rezerBtn1.style.color = "black";
    inputPlaceholder.placeholder = "Bilet nömrəsi (13 simvol)";
});


function NavItems(displayedItem) {
    const navItems = [navItem2, navItem3, navItem4, navItem5, navItem6, navItem7, navItem8, navItem1];
    const navMain = [navMain1, navMain2, navMain3, navMain4, navMain5, navMain6, navMain7];
    const line = [line1, line2, line3, line4, line5, line6, line7]

    navItems.forEach(function(item) {
        item.style.display = "none";
    });
    navMain.forEach(function(item){
        item.style.color = "#01357E";
        item.style.marginLeft = "0px";
    });
    line.forEach(function(item){
        item.style.width = "0px"
        item.style.margin= "20px 5px 0px 0px"
    })

    navItems[displayedItem].style.display = "block";
    navMain[displayedItem].style.color = "#40b7de";
    line[displayedItem].style.width="25px"
    line[displayedItem].style.height= "2px"
    line[displayedItem].style.margin= "20px 10px 0px 0px"
    line[displayedItem].style.background= "#40b7de"
    line[displayedItem].style.transitionDuration = "0.5s"
}

for (let i = 1; i <= 7; i++) {
    const navMain = document.getElementById(`nav-main${i}`);
    navMain.addEventListener("click", function() {
        NavItems(i - 1);
    });
}

const buttons = [barBtn1, barBtn2, barBtn3, barBtn4];
const cards = [cards1, cards2, cards3, cards4];
buttons.forEach((button, index) => {
    button.addEventListener("click", () => {
        buttons.forEach((btn, i) => {
            btn.style.background = i === index ? "#fff" : "rgb(16 16 16 / 20%)";
            btn.style.color = i === index ? "#01357E" : "#fff";
        });
        cards.forEach((card, i) => card.style.display = i === index ? "flex" : "none");
    });
});




