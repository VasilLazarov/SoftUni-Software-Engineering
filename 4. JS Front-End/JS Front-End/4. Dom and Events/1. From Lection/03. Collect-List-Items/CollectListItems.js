function extractText() {
    const arrLines = Array.from(document.querySelectorAll("li"));

    const textForTextArea = arrLines.map((line) => line.textContent).join("\n");

    console.log(textForTextArea);

    document.querySelector("textarea").value = textForTextArea;

    /*const text = document.querySelector("ul").textContent;
    console.log(text);
    document.querySelector("textarea").value = document.querySelector("ul").textContent;
*/
}