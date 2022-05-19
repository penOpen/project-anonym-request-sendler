
/**
 * Switcher to get state management shits. Return values uses in the hook useReducer(param), when param - this function returns (see example)
 * @param {"create" | "view"} page page you want state of
 * @returns {[(state: object, action: {type: string, payload?: any}) => newState, initialState] | null} reducer and initialState or null if page not find
 * @example const [state, dispatch] = useReducer(...getStateManagement("create"))
 */
export default function getStateManagement(page) {
  
  switch(page) {
    case "create":
      return createState()
    case "view":
      return viewState()
    default:
      return null
  }

}

function createState() {
  const initialState = {
    type: "0",
    name: "Untitled",
    description: "No description",
    files: [],
    modalClicked: {
      ok: false
    }
  }

  const reducer = (state, action) => {
    switch (action.type) {
      case "type": 
        return {
          ...state,
          type: action.payload
        }
      case "name":
        return {
          ...state, 
          name: action.payload
        }
      case "description":
        return {
          ...state,
          description: action.payload
        }
      case "files":
        return {
          ...state,
          files: action.payload
        }
      case "modalclicked":
        document.body.style.overflow = "hidden"
        return {
          ...state,
          modalClicked: {
            ok: true,
            name: action.payload
          }
        }
      case "modalunmount":
        document.body.style.overflow = null
        return {
          ...state,
          modalClicked: {
            ok: false
          }
        }
      
      default: return {...state}
    }
  }

  return [reducer, initialState]
}

function viewState() {

  const initialState = {
    modalClicked: {
      ok: false
    },
    isLoad: true,
    isError: false,
    name: "untitled",
    description: "no description",
    status: 0,
    type: "0",
    files: [],
    moderator: {
      name: "noid",
      avatar: "png-transparent-user-computer-icons-user-miscellaneous-cdr-rectangle.png"
    },
    comments: [
      {
        type: "user",
        id: 0,
        time: 0,
        text: "no text",
        files: null
      }
    ],
    newComment: {
      text: "",
      files: []
    }
  }

  function reducer(state, action) {
    switch (action.type) {
      case "onload":
        return {
          ...state,
          isLoad: false
        }
      case "fetch":
        return {
          ...state,
          ...action.payload
        }
      case "fetchfailed":
        return {
          ...state,
          isError: true
        }
      case "files":
        return {
          ...state,
          newComment: {
            text: state.newComment.text,
            files: action.payload
          }
        }
      case "commenttextchange":
        return {
          ...state,
          newComment: {
            text: action.payload,
            files: state.newComment.files
          }
        }
      case "modalclicked":
        document.body.style.overflow = "hidden"
        return {
          ...state,
          modalClicked: {
            ok: true,
            name: action.payload
          }
        }
      case "modalunmount":
        document.body.style.overflow = null
        return {
          ...state,
          modalClicked: {
            ok: false
          }
        }
      default:
        return {...state}
    }
  }

  return [reducer, initialState]
}