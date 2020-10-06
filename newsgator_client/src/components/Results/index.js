import React from 'react';
import Card from 'react-bootstrap/Card';
import stories from './../../constants/stories';

const Results = () => (
  <React.Fragment>
    <h2>Top Stories</h2>
    {stories.map(story => 
      <Card key={story.articlesId}>
        <Card.Header>
          <Card.Title>{story.source}</Card.Title>
          <Card.Subtitle>{story.author} - {story.source}</Card.Subtitle>
        </Card.Header>
        <Card.Body>
          <Card.Text>{story.summary}</Card.Text>
        </Card.Body>
        <Card.Footer>
          <a href={story.url}>Link To Full Story</a>
        </Card.Footer>
      </Card>)}
  </React.Fragment>
)

export default Results;