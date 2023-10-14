document.addEventListener('DOMContentLoaded', function () {
    var openModalBtn = document.getElementById('openModalBtn');
    var modal = document.getElementById('loginModal');
    var closeModalBtn = document.querySelector('.modal .close');
    var submitBtn = document.querySelector('#loginModal form button[type="submit"]');

    openModalBtn.addEventListener('click', function () {
        modal.classList.add('show');
        document.body.classList.add('no-scroll');
    });

    closeModalBtn.addEventListener('click', function () {
        modal.classList.remove('show');
        document.body.classList.remove('no-scroll');
    });

    modal.addEventListener('click', function (event) {
        if (event.target == modal) {
            modal.classList.remove('show');
            document.body.classList.remove('no-scroll');
        }
    });

    submitBtn.addEventListener('click', function (event) {
        event.preventDefault();
        var username = document.querySelector('#loginModal form input[name="username"]').value;
        var password = document.querySelector('#loginModal form input[name="password"]').value;
    });
});

///

function rollDice() {
    return Math.floor(Math.random() * 6) + 1;
}

function setDiceValue(diceElement, diceValue) {
    diceElement.classList.remove("front", "top", "right", "left", "bottom", "back");
    switch (diceValue) {
        case 1:
            diceElement.classList.add("front");
            break;
        case 2:
            diceElement.classList.add("top");
            break;
        case 3:
            diceElement.classList.add("right");
            break;
        case 4:
            diceElement.classList.add("left");
            break;
        case 5:
            diceElement.classList.add("bottom");
            break;
        case 6:
            diceElement.classList.add("back");
            break;
        default:
            break;
    }
}

const diceElement = document.querySelector(".dice");
const diceValue = rollDice();
setDiceValue(diceElement, diceValue);




/////
document.addEventListener('DOMContentLoaded', function () {
    const playButton = document.getElementById('playButton');

    playButton.addEventListener('click', function () {
        playButton.classList.add('clicked');
        setTimeout(function () {
            playButton.classList.remove('clicked');
        }, 500);
    });

    const cards = document.querySelectorAll('.card');
    cards.forEach(card => {
        card.addEventListener('mouseover', function () {
            card.classList.add('flipped');
        });
        card.addEventListener('mouseout', function () {
            card.classList.remove('flipped');
        });
    });
});