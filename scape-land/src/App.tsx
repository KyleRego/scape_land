import { useState, useEffect } from 'react';
import Prompt from './Prompt';
import apiClient from './apiClient';

import './App.css';
import PromptDto from './dtos/PromptDto';

function App() {
  useEffect(() => {
    apiClient.get<PromptDto>('/api/Prompt')
      .then(response => {
        setPrompt(response.data);
      })
      .catch(error => {
        console.error('Error fetching data:', error);
      });
  }, []);

  const [prompt, setPrompt] = useState<PromptDto | null>(null);

  if (prompt === null) return <div>Loading</div>;

  return (
    <>
      <Prompt text={prompt.text} options={prompt.options} />
    </>
  );
}

export default App
