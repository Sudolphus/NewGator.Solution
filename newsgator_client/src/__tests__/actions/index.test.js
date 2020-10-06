import * as a from './../../constants/actions';
import * as c from './../../actions/index';

describe('actions', ()=>{
  it('should be able to create an add source action', ()=>{
    expect(c.addSource('test')).toEqual({
      type: a.ADD_SOURCE,
      name: 'test'
    });
  });

  it('should be able to crate a remove source action', ()=>{
    expect(c.removeSource('test')).toEqual({
      type: a.REMOVE_SOURCE,
      name: 'test'
    });
  });

  it('should be able to create a change topic action', ()=>{
    expect(c.changeTopic('test')).toEqual({
      type: a.CHANGE_TOPIC,
      topic: 'test'
    });
  });
});