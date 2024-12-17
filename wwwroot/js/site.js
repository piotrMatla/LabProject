'use strict';

window.addEventListener('scroll', () => {
    const navigation = document.querySelector('.navigation');
    if (navigation.getBoundingClientRect().top + window.scrollY > 100) {
        navigation.classList.add('nav_bg');
    } else {
        navigation.classList.remove('nav_bg');
    }
});