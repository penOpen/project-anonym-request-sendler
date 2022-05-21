import React from 'react'
import './EULA.css'
import a from './Memes/-ztXSlh7svkiX7TekYLLIBAhCq73BH__8GBvb9KTagppitRP-sn41qtwYHX3374IfMxvef1zgGwdc_6ZH-b_-h8b.jpg'
import b from './Memes/5BY5obzoCuXn70xLMjCpvT2RI2niJIlddMMhj0WdZpq2Oeh8hrf8iqH5QmRYFrs_9x2NZ_i8Sovcuqx0x5tqW8I0.jpg'
import c from './Memes/Ah89hpPi3irVdkl9fv4_YHQxqmKFrw04BKhlkTKZXqns2_uL_PyeGl78tDgGHNIE7dzMzwfTTynmbepcOKdTb-JT.jpg'
import d from './Memes/DT8tuL29WGkjcMKlZhM8ZQZ8BEDLGmhuQ1XXmTTi_-KkZ7zknPH2KqQQkFMrDJAKKKglSXFusaoO3MD9JjBZEI9c.jpg'
import f from './Memes/F1oAwqLXZbzaTMfxtrwbHznnY4Xav414uS4gVjX-aff5gUe_MG30wwmUTWS2xF4ql4SHxF1SbSiefxqAkSYetKnK.jpg'
import g from './Memes/p1CKnOX5uZRidwrKrJp3j6CTtmVx1UX3sw_IiwxgTAszWEIU7I6Q3LK8oXwjWMj9yEOre4T7DDubsn7wZK3hyfzK.jpg'
import e from './Memes/T4N5n9HtUKZHNbifYi4H5DPR14BsiiM0BhbURQglHyQkMm9RQ52VNUtU1FXgv-J_3WzRck0otExnukK_VoXPQudG.jpg'
import q from './Memes/tVP0oD5aYHQAIio7azfiNTlxwpMOev8mMj9UIOsXXSoQCxCl21moGdRHP-rv319qct1CRFWdh00j8mH1Ui4zUBv-.jpg'
import w from './Memes/UNihS9eP41vcZzqMPBFvVspGjjg2EZ2USVNcaYei-C4FNSxwsxVhwMW7xnvQLCy3MtzWPt7_L9MNnugIIUCYgJTH.jpg'
import r from './Memes/WOuak381oDysnRypynhLz0emIPiYPdXMdweI5XG9uZEwW6SzcsemL3CR-fBsgi2iuLd_E_QrEZ668PgHmVbB7S4k.jpg'
import t from './Memes/zqFMGyIXeRDiUcClYLSyNmb1JaqFButpIIW9VLf6m9IFYIE24xepH_rs-toRzmd33q9vk35_0YB4QiAXt0VgFr9V.jpg'

function EULA() {
  return (
    <div className='content eula center-items column-items'>
      <h2>Мы не знали, что сюда вписать, поэтому я вставил сюда мемы</h2>
      <img src={a} alt={":("}></img>
      <img src={b} alt={":("}></img>
      <img src={c} alt={":("}></img>
      <img src={d} alt={":("}></img>
      <img src={e} alt={":("}></img>
      <img src={f} alt={":("}></img>
      <img src={g} alt={":("}></img>
      <img src={q} alt={":("}></img>
      <img src={w} alt={":("}></img>
      <img src={r} alt={":("}></img>
      <img src={t} alt={":("}></img>
      <h2>В случае сдачи</h2>
      <video controls src='videoplayback.mp4'/>
    </div>
  )
}

export default EULA