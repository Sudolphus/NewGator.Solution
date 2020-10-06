import React from 'react';
import PropTypes from 'prop-types';
import { withStory } from './../StoryList';
import Article from './../Article';

const Results = ({ stories }) => (
  <React.Fragment>
    <h2>Top Stories</h2>
    {stories.map(story => <Article key={story.articlesId} story={story} />)}
  </React.Fragment>
)

Results.propTypes = {
  stories: PropTypes.array
}

export default withStory(Results);