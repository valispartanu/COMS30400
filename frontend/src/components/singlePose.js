import { Navbar, Nav } from 'react-bootstrap'
import './singlepose.css';

const SinglePose = ({picture, pose_title}) => {
    return(
        <div class="single_pose_div">
            <Navbar className={"navbar-change"} expand="lg">
                <h1 class="pose_title_text">{pose_title}</h1>
            </Navbar>
            <img src={picture + ".gif"} alt={"falo"}/>
        </div>
    )
}

export default SinglePose