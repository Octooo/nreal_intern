using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prism : MonoBehaviour
{
    public int n = 6;// ��n�p�`��n
    void Start()
    {
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();// ���b�V���t�B���^�[
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();// ���b�V�������_���[
        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();// ���b�V���R���C�_�[
        Mesh mesh = new Mesh();// ���b�V��
        Vector3[] vertices = new Vector3[n * 6];// ���b�V���̒��_���W
        int[] triangles = new int[(n - 1) * 12];// ���b�V���̎O�p�`���
        for (int i = 0; i < n; i++)
        {
            // ��ʂ̒��_
            vertices[i] = (Quaternion.Euler(0, 0, (360f / n) * i) * Vector3.up) + Vector3.back * 0.5f;
            vertices[n + i] = vertices[i] + Vector3.forward;
        }
        for (int i = 0; i < n; i++)
        {
            // ���ʂ̒��_
            vertices[n * 2 + i * 4 + 0] = vertices[0 + i];
            vertices[n * 2 + i * 4 + 1] = vertices[(1 + i) % n];
            vertices[n * 2 + i * 4 + 2] = vertices[n + (1 + i) % n];
            vertices[n * 2 + i * 4 + 3] = vertices[n + i];
        }
        for (int i = 0; i < n - 2; i++)
        {
            // ��O�̒��
            triangles[i * 3 + 0] = 0;
            triangles[i * 3 + 1] = 2 + i;
            triangles[i * 3 + 2] = 1 + i;
            // ���̒��
            triangles[(n - 2) * 3 + i * 3 + 0] = n;
            triangles[(n - 2) * 3 + i * 3 + 1] = n + 1 + i;
            triangles[(n - 2) * 3 + i * 3 + 2] = n + 2 + i;
        }// ~ (n-2)*6
        for (int i = 0; i < n; i++)
        {
            // i�Ԗڂ̑���
            triangles[(n - 2) * 6 + i * 6 + 0] = n * 2 + i * 4 + 0;
            triangles[(n - 2) * 6 + i * 6 + 1] = n * 2 + i * 4 + 1;
            triangles[(n - 2) * 6 + i * 6 + 2] = n * 2 + i * 4 + 2;
            triangles[(n - 2) * 6 + i * 6 + 3] = n * 2 + i * 4 + 2;
            triangles[(n - 2) * 6 + i * 6 + 4] = n * 2 + i * 4 + 3;
            triangles[(n - 2) * 6 + i * 6 + 5] = n * 2 + i * 4 + 0;
        }// ~ (n-1)*12
        mesh.SetVertices(vertices);// ���b�V���̒��_��ݒ�
        mesh.SetTriangles(triangles, 0);// ���b�V���̎O�p�`��ݒ�
        mesh.RecalculateNormals();// �@���x�N�g���̐ݒ�
        meshFilter.sharedMesh = mesh;// ���b�V���t�B���^�[�Ƀ��b�V����ݒ�
        meshCollider.sharedMesh = mesh;// ���b�V���R���C�_�[�Ƀ��b�V����ݒ�
    }
}