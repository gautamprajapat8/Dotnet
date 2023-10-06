const express = require('express');
const axios = require('axios');

const app = express();
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
      prompt: `Write a Shayari about ${keyword}`,
      max_tokens: 50, // Adjust the length of Shayari as needed
    }, {
      headers: {
        'Authorization': 'Bearer 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',
        'Content-Type': 'application/json',
      },
    });

    const shayari = response.data.choices[0].text;
    res.json({ shayari });
  } catch (error) {
    console.error('Error generating Shayari:', error);
    res.status(500).json({ error: 'An error occurred while generating Shayari.' });
  }
});

// Start the server
app.listen(port, () => {
  console.log(`Server is running on port ${port}`);
});
