window.loadLottieAnimation = (elementId) => {
    const anim = lottie.loadAnimation({
        container: document.getElementById(elementId),
        renderer: 'canvas',
        loop: false,
        autoplay: false,
        path: "resources/Bell_Notification_01.json"
    });

    // Store animation globally so you can control it from Blazor
    window.lottieAnimations = window.lottieAnimations || {};
    window.lottieAnimations[elementId] = anim;
};
window.playLottieAnimation = (elementId) => {
    if (window.lottieAnimations && window.lottieAnimations[elementId]) {
        window.lottieAnimations[elementId].play();
    }
};
window.resetLottieAnimation = (elementId) => {
    if (window.lottieAnimations && window.lottieAnimations[elementId]) {
        const anim = window.lottieAnimations[elementId];
        anim.goToAndStop(0, true); // true = frame-based
    }
};

