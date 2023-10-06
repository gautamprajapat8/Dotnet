const express = require('express');
const cors = require('cors');
const axios = require('axios');

const app = express();
app.use(cors());

const port = process.env.PORT || 3000;

// Define an API endpoint for generating Shayari
app.get('/generate-shayari', async (req, res) => {
  const keyword = req.query.keyword;

  if (!keyword) {
    return res.status(400).json({ error: 'Keyword is required.' });
  }

  try {
    // Make a POST request to the GPT-3 API
    const response = await axios.post('https://api.openai.com/v1/engines/davinci/completions', {
      prompt: `Write a poetry on ${keyword}`,
      max_tokens: 80, // Adjust the length of Shayari as needed
    }, {
      headers: {
        'Authorization': 'Bearer YOUR_API_KEY_HERE',
        'Content-Type': 'application/json',
      },
    });

    const shayari = response.data.choices[0].text;
    
    // Format Shayari by splitting sentences and adding line breaks
    const formattedShayari = shayari.split('.').map(sentence => sentence.trim()).join('.\n');

    res.json({ shayari: formattedShayari });
  } catch (error) {
    console.error('Error generating Shayari:', error);
    res.status(500).json({ error: 'An error occurred while generating Shayari.' });
  }
});

// Start the server
app.listen(port, () => {
  console.log(`Server is running on port ${port}`);
});
