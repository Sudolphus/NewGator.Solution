import React from 'react';
import Article from './../Article';
import stories from './../../constants/stories';

const Results = () => (
  <React.Fragment>
    <h2>Top Stories</h2>
    {stories.map(story => <Article story={story} />)}
  </React.Fragment>
)

export default Results;