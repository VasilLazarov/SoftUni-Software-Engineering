function SetLimit() {
    let num = document.getElementById("limitInput").value || 3;

    window.location = "https://localhost:7195/Numbers/Limit?num=" + num;
}