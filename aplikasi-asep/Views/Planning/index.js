document.addEventListener("DOMContentLoaded", function () {
    const successMessage = document.getElementById("successMessage");

    if (successMessage) {
        setTimeout(() => {
            successMessage.style.transition = "opacity 0.5s ease";
            successMessage.style.opacity = "0";

            setTimeout(() => {
                successMessage.remove();
            }, 500);
        }, 3000);
    }
});