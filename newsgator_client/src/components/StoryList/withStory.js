import React from 'react';
import StoryContext from './context';
import stories from './../../constants/stories';


const storyList = stories;

const withStory = Component => props => (
  <StoryContext.Consumer>
    <Component {...props} stories={storyList} />
  </StoryContext.Consumer>
)

export default withStory;