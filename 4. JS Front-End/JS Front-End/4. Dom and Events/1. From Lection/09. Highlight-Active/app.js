function focused() {
    const inputs = Array.from(document.querySelectorAll("input"));

    inputs.forEach((input) => {
        input.addEventListener("focus", (e) =>{
            e.currentTarget.parentElement.classList.add("focused");
        });
        input.addEventListener("blur", (e) => {
            e.currentTarget.parentElement.classList.remove("focused");
        });
    });

}