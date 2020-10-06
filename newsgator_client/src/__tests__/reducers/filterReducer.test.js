import { filterReducer } from '../../reducers';
import * as a from '../../constants/actions';

describe('filterReducer', ()=>{
  const initial_state = {
    sources: ["BBC News", "Associated Press", "Reuters", "Bloomberg", "New York Times", "CBS News", "Wall Street Journal", "Washington Post", "Politico"],
    topic: ''
  }

  it('should do nothing if given a blank reducer', ()=>{
    expect(filterReducer({}, {type:null})).toEqual({});
  });

  it('should match default state', ()=>{
    expect(filterReducer(initial_state, {type:null})).toEqual(initial_state);
  });

  it('should be able to add a source to the source list', ()=>{
    const action = {
      type: a.ADD_SOURCE,
      name: "Test Name"
    };
    expect(filterReducer(initial_state, action)).toEqual({
      sources: ["BBC News", "Associated Press", "Reuters", "Bloomberg", "New York Times", "CBS News", "Wall Street Journal", "Washington Post", "Politico", "Test Name"],
      topic: ""
    });
  });

  it('should be able to remove a source from the source list', ()=>{
    const action = {
      type: a.REMOVE_SOURCE,
      name: "BBC News"
    };
    expect(filterReducer(initial_state, action)).toEqual({
      sources: ["Associated Press", "Reuters", "Bloomberg", "New York Times", "CBS News", "Wall Street Journal", "Washington Post", "Politico"],
      topic: ""
    })
  });

  it('should be able to change the topic', ()=>{
    const action = {
      type: a.CHANGE_TOPIC,
      topic: 'Test'
    };
    expect(filterReducer(initial_state, action)).toEqual({
      sources: ["BBC News", "Associated Press", "Reuters", "Bloomberg", "New York Times", "CBS News", "Wall Street Journal", "Washington Post", "Politico"],
      topic: 'Test'
    });
  });
});