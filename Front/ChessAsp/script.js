/* SPDX-License-Identifier:  Apache-2.0
 * Copyright 2021-2022 Jorengarenar
 */

const tgfw = new TGFW("chess", "http://localhost:5000");

window.onload = function() {
  tgfw.initDom(document.querySelector("main"));
}
