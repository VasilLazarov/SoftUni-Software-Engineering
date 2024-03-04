function solve() {
  const text = document.querySelector('#input').value;
  const sentences = text.split('.').filter((element) => element !== '');
  const countOfParagraphs = Math.ceil(sentences.length / 3);
  for (let index = 0; index < countOfParagraphs; index++) {
    console.log(`Index: ${index}`);
    const currP = document.createElement('p');
    let countOfSentencesFotTheseP = 3;
    let textForTheseP = '';
    if(sentences.length < 3){
      countOfSentencesFotTheseP = sentences.length;
    }
    console.log(`Count of sentences: ${countOfSentencesFotTheseP}`);
    for (let i = 0; i < countOfSentencesFotTheseP; i++) {
      textForTheseP += `${sentences.shift()}.`;
    }
    currP.textContent = textForTheseP;
    document.querySelector('#output').appendChild(currP);
  }
}