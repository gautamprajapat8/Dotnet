const generateBtn = document.getElementById('generate-btn');
const keywordInput = document.getElementById('keyword');
const shayariContainer = document.getElementById('shayari-container');

generateBtn.addEventListener('click', () => {
    const keyword = keywordInput.value;

    // Send a request to your backend API to generate Shayari based on the keyword
    fetch(`http://localhost:3000/generate-shayari?keyword=${encodeURIComponent(keyword)}`)
        .then(response => response.json())
        .then(data => {
            const formattedShayari = data.shayari.split('.').map(sentence => sentence.trim()).join('.\n');
            // Update the shayariContainer with the formatted Shayari
            shayariContainer.textContent = formattedShayari;
        })
        .catch(error => {
            console.error('Error generating Shayari:', error);
        });
});
