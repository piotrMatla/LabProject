'use strict';

window.addEventListener('scroll', () => {
    const navigation = document.querySelector('.navigation');
    if (navigation.getBoundingClientRect().top + window.scrollY > 100) {
        navigation.classList.add('nav_bg');
    } else {
        navigation.classList.remove('nav_bg');
    }
});

const successModal = () => {
    Swal.fire({
        title: "Good job!",
        text: "Enjoy the additional features!",
        icon: "success"
    })
}

const image = document.getElementById('tilt_image');

document.addEventListener('mousemove', (event) => {
    const imageContainer = document.querySelector('.image_container');
    const { clientX, clientY } = event;

    const { left, top, width, height } = imageContainer.getBoundingClientRect();
    const centerX = left + width / 2;
    const centerY = top + height / 2;

    const deltaX = (clientX - centerX) / (width / 2);
    const deltaY = (clientY - centerY) / (height / 2); 

    const tiltX = deltaY * 10;  
    const tiltY = -deltaX * 10; 

    image.style.transform = `rotateX(${tiltX}deg) rotateY(${tiltY}deg)`;
});

document.querySelector('.image-container').addEventListener('mouseleave', () => {
    image.style.transform = 'rotateX(0deg) rotateY(0deg)';
});
