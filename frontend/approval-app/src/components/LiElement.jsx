export default function LiElement (props){
  return (
    <li>
      <p>
        <strong>{props.title}</strong>{props.description}
      </p>
    </li>

  )
}