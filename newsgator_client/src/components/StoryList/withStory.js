import React from 'react';
import StoryContext from './context';

const withStory = Component => props => (
  <StoryContext.Consumer>
    {stories => <Component {...props} stories={stories} />}
  </StoryContext.Consumer>
)

export default withStory;