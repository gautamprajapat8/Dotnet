const generateBtn = document.getElementById('generate-btn');
const keywordInput = document.getElementById('keyword');
const shayariContainer = document.getElementById('shayari-container');

generateBtn.addEventListener('click', () => {
    const keyword = keywordInput.value;

    // Send a request to your backend API to generate Shayari based on the keyword
    fetch(`http://localhost:3000/generate-shayari?keyword=${encodeURIComponent(keyword)}`)
        .then(response => response.text())
        .then(data => {
            shayariContainer.textContent = data;
        })
        .catch(error => {
            console.error('Error generating Shayari:', error);
        });
});
